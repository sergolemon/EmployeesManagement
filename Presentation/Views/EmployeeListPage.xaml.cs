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
    /// Interaction logic for EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        private readonly EmployeeListVm _viewModel;

        public EmployeeListPage()
        {
            InitializeComponent();
            _viewModel = App.GetService<EmployeeListVm>();
            DataContext = _viewModel;

            _viewModel.SelectedItemDetails += ShowItemDetails;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.InitAsync();
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SearchQuery = (sender as TextBox)!.Text;

            await _viewModel.InitAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchQuery = string.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewEmployeePage());
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "data"; // Default file name
            dialog.DefaultExt = ".json"; // Default file extension
            dialog.Filter = "Json files (*.json)|*.json"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string fileName = dialog.FileName;

                bool importResult = await _viewModel.ImportService.ImportAsync(fileName);

                if (importResult)
                {
                    MessageBox.Show("Імпорт завершено!");

                    NavigationService.Refresh();
                }
                else
                    MessageBox.Show("При імпорті виникла проблема! Можливо ці дані вже є в базі.");
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "data"; // Default file name
            dialog.DefaultExt = ".json"; // Default file extension
            dialog.Filter = "Json files (*.json)|*.json"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string fileName = dialog.FileName;
                await _viewModel.ExportService.ExportAsync(fileName);

                MessageBox.Show("Експорт завершено!");
            }
        }

        private async Task ShowItemDetails(EmployeeDetailsVm details)
        {
            var modalWindow = new EmployeeDetailsWindow(details);
            modalWindow.ShowDialog();
        }
    }
}
