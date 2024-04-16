using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Presentation.ViewModels.Controls
{
    public class EmployeeItemVm : ObservableObject
    {
        public Guid Id { get; set; }

        private string fullName;
        public string FullName { get => fullName; set => SetProperty(ref fullName, value); }

        private string phoneNumber;
        public string PhoneNumber { get => phoneNumber; set => SetProperty(ref phoneNumber, value); }

        private string position;
        public string Position { get => position; set => SetProperty(ref position, value); }

        private decimal salary;
        public decimal Salary { get => salary; set => SetProperty(ref salary, value); }

        private EmployeeStatus status;
        public EmployeeStatus Status { get => status; set => SetProperty(ref status, value); }

        private Brush backgroundBrush;
        public Brush BackgroundBrush { get => backgroundBrush; set => SetProperty(ref backgroundBrush, value); }

        public Func<EmployeeItemVm, Task>? RemoveCallback;
        public Func<EmployeeItemVm, Task>? DetailsCallback;

        public EmployeeItemVm()
        {
            
        }

        public EmployeeItemVm(Employee employee, Func<EmployeeItemVm, Task> removeCallback, Func<EmployeeItemVm, Task> detailsCallback)
        {
            Id = employee.Id;
            PhoneNumber = employee.PhoneNumber;
            Position = employee.Position;
            Status = employee.Status;
            BackgroundBrush = employee.Status == EmployeeStatus.Work ? new SolidColorBrush(Colors.WhiteSmoke) : new SolidColorBrush(Colors.MistyRose);
            FullName = string.Join(" ", employee.LastName, employee.FirstName, employee.Patronymic);
            Salary = employee.Salary;
            RemoveCallback += removeCallback;
            DetailsCallback = detailsCallback;
        }
    }
}
