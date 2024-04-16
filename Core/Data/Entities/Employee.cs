using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Patronymic { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public EmployeeStatus Status { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RecruitDate { get; set; }

        public DateTime? QuitDate { get; set; }
    }
}
