using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Riot;

namespace 전적검색
{
    internal class InfoConverter : IValueConverter
    {
        private static int idx = 0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string key = (string)parameter;

            var match = (Match)value;

            if (match == null)
            {
                return "데이터없음";
            }

            return match.Participants[idx++][key];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
