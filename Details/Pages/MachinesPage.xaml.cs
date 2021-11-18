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
using Details.Data;

namespace Details.Pages
{
    public partial class MachinesPage : Page
    {
        public MachinesPage()
        {
            InitializeComponent();
        }


        // Не работает((
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Machine));
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var vacancyForRemoving = DataMachine.SelectedItems.Cast<Machine>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {vacancyForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppDBContext.GetContext().Machines.RemoveRange(vacancyForRemoving);
                    AppDBContext.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!"); 
                    DataMachine.ItemsSource = AppDBContext.GetContext().Machines.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void MachinesPage_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AppDBContext.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataMachine.ItemsSource = AppDBContext.GetContext().Machines.ToList();
            }
        }
    }
}
