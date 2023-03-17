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

namespace GuardPRO.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ApiClient _apiClient;

        public LoginWindow()
        {
            _apiClient = new ApiClient();

            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberTextBox.Text, out int number))
            {
                MessageBox.Show("Введите число");
                return;
            }

            var applicant = await _apiClient.Login(number);
            if (applicant == null)
            {
                MessageBox.Show("Неверный код сотрудника");
                return;
            }
        }
    }
}
