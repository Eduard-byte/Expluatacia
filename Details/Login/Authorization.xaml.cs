using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Details.Data;

namespace Details.Login
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> users = AppDBContext.GetContext().Users.ToList();
                User u = users.FirstOrDefault(p => p.Password == TbPass.Password && p.Email == TbLogin.Text);

                if (u != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Owner = this;
                    Hide();
                    mainWindow.Show();
                }
                else
                    MessageBox.Show("Неверный логин или пароль");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Authorization_OnClosing(object sender, CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите закрыть приложение?",
                "Выйти", MessageBoxButton.OKCancel,
                MessageBoxImage.Question);

            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
    }
}
