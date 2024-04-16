using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class EmployeeTestData
    {
        public static IEnumerable<Employee> Employees { get; } = new List<Employee>()
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Snow",
                    PhoneNumber = "123-456-7890",
                    Address = "вул. Гагаріна, буд. 10",
                    Position = "Менеджер",
                    Salary = 50000,
                    Status = EmployeeStatus.Work,
                    BirthDate = new DateTime(1990, 1, 1),
                    RecruitDate = new DateTime(2020, 1, 1)
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Maria",
                    LastName = "Sidrenko",
                    Patronymic = "Petrovna",
                    PhoneNumber = "987-654-3210",
                    Address = "просп. Перемоги, буд. 5",
                    Position = "Розробник",
                    Salary = 60000,
                    Status = EmployeeStatus.Quit,
                    BirthDate = new DateTime(1985, 5, 10),
                    RecruitDate = new DateTime(2018, 6, 15),
                    QuitDate = new DateTime(2022, 3, 31)
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith",
                    Patronymic = "Michael",
                    PhoneNumber = "111-222-3333",
                    Address = "123 Main St",
                    Position = "Manager",
                    Salary = 55000,
                    Status = EmployeeStatus.Work,
                    BirthDate = new DateTime(1987, 10, 20),
                    RecruitDate = new DateTime(2019, 3, 15)
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Doe",
                    Patronymic = "Marie",
                    PhoneNumber = "555-666-7777",
                    Address = "456 Elm St",
                    Position = "Developer",
                    Salary = 65000,
                    Status = EmployeeStatus.Work,
                    BirthDate = new DateTime(1992, 12, 5),
                    RecruitDate = new DateTime(2021, 8, 10)
                }
            };
    }

}
