using Core.Data.Entities;
using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Presentation.ViewModels
{
    internal class AddNewEmployeeVm : ObservableObject, INotifyDataErrorInfo
    {
        private string lastName;
        public string LastName { get => lastName; set { SetProperty(ref lastName, value); ValidateLastName(); } }

        private string firstName;
        public string FirstName { get => firstName; set { SetProperty(ref firstName, value); ValidateFirstName(); } }

        private string? patronymic;
        public string? Patronymic { get => patronymic; set => SetProperty(ref patronymic, value); }

        private string phoneNumber;
        public string PhoneNumber { get => phoneNumber; set { SetProperty(ref phoneNumber, value); ValidatePhoneNumber(); } }

        private string position;
        public string Position { get => position; set { SetProperty(ref position, value); ValidatePosition(); } }

        private string address;
        public string Address { get => address; set { SetProperty(ref address, value); ValidateAddress(); } }

        private decimal salary;
        public decimal Salary { get => salary; set { SetProperty(ref salary, value); ValidateSalary(); } }

        private DateTime birthDate = new DateTime(2000, 1, 1);
        public DateTime BirthDate { get => birthDate; set { SetProperty(ref birthDate, value); ValidateBirthDate(); } }

        private readonly IEmployeeRepository _employeeRepository;

        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public AddNewEmployeeVm(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> SaveNewEmployeeAsync()
        {
            ValidateLastName();
            ValidateFirstName();
            ValidateSalary();
            ValidatePosition();
            ValidatePhoneNumber();
            ValidateAddress();
            ValidateBirthDate();

            if(HasErrors) return false;

            await _employeeRepository.AddAsync(new Employee 
            { 
                FirstName = FirstName, 
                LastName = LastName,
                Patronymic = Patronymic,
                Salary = Salary,
                Address = Address,
                BirthDate = BirthDate,
                RecruitDate = DateTime.Now,
                PhoneNumber = PhoneNumber,
                Position = Position,
                Status = EmployeeStatus.Work
            });

            return true;
        }

        private void ValidateBirthDate()
        {
            ClearErrors(nameof(BirthDate));
            if (BirthDate > DateTime.Now)
                AddError(nameof(BirthDate), "Дата народження не може бути більшою за поточну дату.");
            if (BirthDate.Equals(default))
                AddError(nameof(BirthDate), "Дату народження не вказано.");
        }

        private void ValidateSalary()
        {
            ClearErrors(nameof(Salary));
            if (Salary <= 0)
                AddError(nameof(Salary), "Заробітна плата повинна бути більше 0.");
        }

        private void ValidateLastName()
        {
            ClearErrors(nameof(LastName));
            if (string.IsNullOrWhiteSpace(LastName))
                AddError(nameof(LastName), "Прізвище не може бути порожнім.");
        }

        private void ValidateAddress()
        {
            ClearErrors(nameof(Address));
            if (string.IsNullOrWhiteSpace(Address))
                AddError(nameof(Address), "Адреса не може бути порожньою.");
        }

        private void ValidatePhoneNumber()
        {
            ClearErrors(nameof(PhoneNumber));
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                AddError(nameof(PhoneNumber), "Номер телефону не може бути порожнім.");
        }

        private void ValidateFirstName()
        {
            ClearErrors(nameof(FirstName));
            if (string.IsNullOrWhiteSpace(FirstName))
                AddError(nameof(FirstName), "Ім'я не може бути порожнім.");
        }

        private void ValidatePosition()
        {
            ClearErrors(nameof(Position));
            if (string.IsNullOrWhiteSpace(Position))
                AddError(nameof(Position), "Посада не може бути порожньою.");
        }

        public bool HasErrors => _errorsByPropertyName.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ?
                _errorsByPropertyName[propertyName] : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
