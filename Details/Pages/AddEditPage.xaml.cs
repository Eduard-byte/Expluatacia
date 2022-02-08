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
    public partial class AddEditPage : Page
    {
        private readonly Machine _machine = new Machine();

        public AddEditPage(Machine selectedMachine)
        {
            InitializeComponent();

            if (selectedMachine != null)
                _machine = selectedMachine;

            DataContext = _machine;
            ComboTypeMachin.ItemsSource = AppDBContext.GetContext().TypeMachines.ToList();
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверка перед сохранением
            StringBuilder errors = new StringBuilder();

            if(_machine.Name == null)
                errors.AppendLine("Укажите название станка.");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_machine.Id == 0)
                AppDBContext.GetContext().Machines.Add(_machine);

            try
            {
                AppDBContext.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена.");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
