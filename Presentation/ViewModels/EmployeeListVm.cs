using Core.Data.Entities;
using Core.Interfaces;
using Presentation.Interfaces;
using Presentation.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Presentation.ViewModels
{
    internal class EmployeeListVm : ObservableObject
    {
        private string searchQuery = string.Empty;
        public string SearchQuery { get => searchQuery; set => SetProperty(ref searchQuery, value); }

        private decimal averageSalary;
        public decimal AverageSalary { get => averageSalary; set => SetProperty(ref averageSalary, value); }

        public int count;
        public int Count { get => count; set => SetProperty(ref count, value); }

        public event Func<EmployeeDetailsVm, Task> SelectedItemDetails;

        private ObservableCollection<EmployeeItemVm> employees = new ObservableCollection<EmployeeItemVm>();
        public ObservableCollection<EmployeeItemVm> Employees { get => employees; set => SetProperty(ref employees, value); }

        private readonly IEmployeeRepository _employeeRepository;
        private readonly Dispatcher _dispatcher;

        public IExportService ExportService { get; }
        public IImportService ImportService { get; }

        public EmployeeListVm(IEmployeeRepository employeeRepository, Dispatcher dispatcher, IExportService exportService, IImportService importService)
        {
            _employeeRepository = employeeRepository;
            _dispatcher = dispatcher;

            ExportService = exportService;
            ImportService = importService;
        }

        public async Task InitAsync()
        {
            var query = SearchQuery.ToLower();

            Expression<Func<Employee, bool>> filtersExpr = null!;

            if (!string.IsNullOrEmpty(query))
                filtersExpr = empl => (empl.LastName + " " + empl.FirstName + " " + empl.Patronymic).ToLower().Contains(query) || empl.PhoneNumber.Contains(query);

            var employees = await _employeeRepository.GetAsync(filtersExpr);
            var items = employees.Select(empl => new EmployeeItemVm(empl, DeleteEmployeeItemAsync, DetailsEmployeeItemAsync));

            Count = await _employeeRepository.GetCountByWorkEmployeesAsync();
            if (Count > 0) AverageSalary = await _employeeRepository.GetAverageSalaryByWorkEmployeesAsync(); else AverageSalary = 0;

            await _dispatcher.BeginInvoke(() => { Employees = new ObservableCollection<EmployeeItemVm>(items); });
        }

        private async Task DeleteEmployeeItemAsync(EmployeeItemVm employee)
        {
            await _employeeRepository.RemoveAsync(new Core.Data.Entities.Employee { Id = employee.Id });

            await _dispatcher.BeginInvoke(async () => 
            {
                Count = await _employeeRepository.GetCountByWorkEmployeesAsync();
                if(Count > 0) AverageSalary = await _employeeRepository.GetAverageSalaryByWorkEmployeesAsync(); else AverageSalary = 0;
                Employees.Remove(Employees.FirstOrDefault(empl => empl.Id == employee.Id)!); 
            });
        }

        private async Task DetailsEmployeeItemAsync(EmployeeItemVm employee)
        {
            var item = await _employeeRepository.GetByIdOrNullAsync(employee.Id)!;
            var itemVm = new EmployeeDetailsVm()
            {
                BirthDate = item.BirthDate,
                QuitDate = item.QuitDate,
                ReqruitDate = item.RecruitDate,
                Address = item.Address,
                FullName = string.Join(" ", item.LastName, item.FirstName, item.Patronymic),
                Id = item.Id,
                PhoneNumber = item.PhoneNumber,
                Position = item.Position,
                Salary = item.Salary,
                Status = item.Status
            };

            itemVm.Quit += QuitEmployee;

            SelectedItemDetails?.Invoke(itemVm);
        }

        private async Task QuitEmployee(EmployeeDetailsVm employee)
        {
            var item = await _employeeRepository.GetByIdOrNullAsync(employee.Id);

            item.Status = Core.Data.Entities.EmployeeStatus.Quit;
            item.QuitDate = DateTime.Now;

            await _employeeRepository.UpdateAsync(item);
            await InitAsync();
        }
    }
}
