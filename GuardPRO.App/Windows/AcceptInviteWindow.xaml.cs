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
    /// Логика взаимодействия для AcceptInviteWindow.xaml
    /// </summary>
    public partial class AcceptInviteWindow : Window
    {
        private ApiClient _apiClient = new ApiClient();
        private Invite _invite;

        public AcceptInviteWindow(Invite selInvite)
        {
            _invite = selInvite;
            DataContext = _invite;

            InitializeComponent();

            NewStateComboBox.ItemsSource = new StatusInvite[]
            {
                StatusInvite.ACCEPT,
                StatusInvite.DENY
            };
            NewStateComboBox.SelectedIndex = 0;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var newStatus = (StatusInvite)NewStateComboBox.SelectedItem;
            await _apiClient.ChangeStatus(_invite.Id, newStatus);

            DialogResult = true;
            MessageBox.Show("Статус изменен");
            Close();
        }
    }
}
