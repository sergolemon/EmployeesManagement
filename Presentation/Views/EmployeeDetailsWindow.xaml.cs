using Core.Data.Entities;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsWindow.xaml
    /// </summary>
    public partial class EmployeeDetailsWindow : Window
    {
        public EmployeeDetailsVm ViewModel { get; }

        public EmployeeDetailsWindow(EmployeeDetailsVm employee)
        {
            InitializeComponent();
            ViewModel = employee;
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Ви впевнені що хочете звільнити \"{ViewModel.FullName}\"?", "Підтвердження операції", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ViewModel.Quit?.Invoke(ViewModel);
                Close();
            }
        }
    }
}
