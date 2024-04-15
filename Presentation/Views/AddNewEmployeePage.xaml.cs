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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for AddNewEmployeePage.xaml
    /// </summary>
    public partial class AddNewEmployeePage : Page
    {
        private AddNewEmployeeVm viewModel;

        public AddNewEmployeePage()
        {
            InitializeComponent();
            viewModel = App.GetService<AddNewEmployeeVm>();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeListPage());
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = await viewModel.SaveNewEmployeeAsync();

            if (result)
            {
                MessageBox.Show("Співробітника додано!");
                viewModel = App.GetService<AddNewEmployeeVm>();
                DataContext = viewModel;
            }
        }
    }
}
