using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using Details.Data;

namespace Details.Pages
{
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();

            ViewEmployee.ItemsSource = AppDBContext.GetContext().Employees.ToList();

            Update();
        }

        private void Search_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void StatusType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            var currentEmployee = AppDBContext.GetContext().Employees.ToList();

            currentEmployee = currentEmployee.Where(emp => emp.FirstName.ToLower().Contains(Search.Text.ToLower())).ToList();

            if (StatusType.SelectedIndex >= 0)
            {
                if (StatusType.SelectedIndex == 0)
                    currentEmployee = currentEmployee.Where(emp => emp.IsPaid).ToList();

                if (StatusType.SelectedIndex == 1)
                    currentEmployee = currentEmployee.Where(emp => !emp.IsPaid).ToList();
            }

            ViewEmployee.ItemsSource = currentEmployee;
        }
    }
}
