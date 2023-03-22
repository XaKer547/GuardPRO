using GuardPRO.API7.Database.Models;
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
    /// Логика взаимодействия для TimeInviteWindow.xaml
    /// </summary>
    public partial class TimeInviteWindow : Window
    {
        private ApiClient _apiClient = new ApiClient();
        private Invite _selInvite;

        public TimeInviteWindow(Invite selInvite)
        {
            _selInvite = selInvite;
            DataContext = _selInvite;
            InitializeComponent();
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TimeSpan.TryParse(TimeTextBox.Text, out var time))
            {
                MessageBox.Show("Неверный формат веремни");
                return;
            }

            await _apiClient.SetTimeOut(_selInvite.Id, time);

            MessageBox.Show("Время выхода задано");
            DialogResult = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
