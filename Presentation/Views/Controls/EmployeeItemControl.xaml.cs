using Presentation.ViewModels;
using Presentation.ViewModels.Controls;
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

namespace Presentation.Views.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeItemControl.xaml
    /// </summary>
    public partial class EmployeeItemControl : UserControl
    {
        private EmployeeItemVm viewModel;

        public EmployeeItemControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Ви впевнені що хочете видалити \"{viewModel.FullName}\"?", "Підтвердження операції", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
                viewModel.RemoveCallback?.Invoke(viewModel); 
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            viewModel = e.NewValue as EmployeeItemVm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.DetailsCallback?.Invoke(viewModel);
        }
    }
}
