using GuardPRO.API7.Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (StatusInvite)value;

            switch (status)
            {
                case StatusInvite.CHECKING:
                    return "Проверка";
                case StatusInvite.ACCEPT:
                    return "Принята";
                case StatusInvite.DENY:
                    return "Отказ";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Логика взаимодействия для InviteWindow.xaml
    /// </summary>
    public partial class InviteWindow : Window
    {
        private ApiClient _apiClient;
        private List<Invite> _invites;

        public InviteWindow()
        {
            _apiClient = new ApiClient();

            InitializeComponent();
        }

        public void ShowDataInvite()
        {
            IEnumerable<Invite> _invitesQuery = _invites;
            if (DateFilterDatePicker.SelectedDate != null)
                _invitesQuery = _invitesQuery.Where(x => x.Date == DateFilterDatePicker.SelectedDate);

            if (GroupRadioButton.IsChecked == true)
                _invitesQuery = _invitesQuery.Where(x => x.Group != null);

            if (IndivdRadioButton.IsChecked == true)
                _invitesQuery = _invitesQuery.Where(x => x.Group == null);

            if (PorazdelCaomboBox.SelectedItem != null)
                _invitesQuery = _invitesQuery.Where(x => x.Applicant.Department.Id == ((Department)PorazdelCaomboBox.SelectedItem).Id);

            if (!string.IsNullOrEmpty(SernameTextBox.Text))
                _invitesQuery = _invitesQuery
                    .Where(x => x.User.Sername.ToLower().Contains(SernameTextBox.Text.ToLower()));

            InviteDataGrid.ItemsSource = _invitesQuery.ToList();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingTextBlock.Visibility = Visibility.Visible;

            _invites = await _apiClient.GetAllInvites();
            PorazdelCaomboBox.ItemsSource = await _apiClient.GetAllDepartment();

            ShowDataInvite();

            LoadingTextBlock.Visibility = Visibility.Collapsed;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ShowDataInvite();
        }
    }
}
