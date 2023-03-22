using GuardPRO.API7.Database.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GuardPRO.App.Converter
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
}
