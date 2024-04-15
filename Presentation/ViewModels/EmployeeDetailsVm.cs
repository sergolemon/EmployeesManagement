using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels
{
    public class EmployeeDetailsVm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime ReqruitDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public DateTime? QuitDate { get; set; }
        public Func<EmployeeDetailsVm, Task> Quit;
        public Visibility QuitBtnVisibility => Status == EmployeeStatus.Quit ? Visibility.Collapsed : Visibility.Visible;
    }
}
