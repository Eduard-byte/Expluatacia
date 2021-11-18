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
using Details.Pages;

namespace Details
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new EmployeePage());
        }

        private void MainFrame_OnContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnMachines.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnMachines.Visibility = Visibility.Visible;
            }
        }

        private void BtnMachines_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MachinesPage());
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
    }
}
