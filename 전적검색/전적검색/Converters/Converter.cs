using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Riot;
using 전적검색;

namespace 전적검색
{
    internal class InfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

namespace 전적검색.Controls
{
    internal class ChampionConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string champion && !string.IsNullOrEmpty(champion))
                return MainViewModel.Singletone.Dragon.GetChampionUrl(champion);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class SpellConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string spell && !string.IsNullOrEmpty(spell))
            {
                string spell_name = MainViewModel.Singletone.DB.GetSpellName(spell);
                return MainViewModel.Singletone.Dragon.GetSpellUrl(spell_name);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class RuneConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string Runes && !string.IsNullOrEmpty(Runes))
            {
                string[] rune = Runes.Split(':');
                string rune_num = string.Empty;
                if (rune.Length == 6)
                {
                    rune_num = rune[1];
                }
                else
                {
                    rune_num = rune[0];
                }

                return MainViewModel.Singletone.DB.GetRuneUrl(rune_num);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class ItemConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string Item && !string.IsNullOrEmpty(Item))
            {
                if (Item == "0")
                    return "https://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/items.png";

                return MainViewModel.Singletone.Dragon.GetItemUrl(Item);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class TimeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime time)
            {
                TimeSpan diff = DateTime.Now - time;

                if( diff.TotalDays < 1)
                {
                    if(diff.TotalHours < 1)
                    {
                        return $"{diff.TotalMinutes.ToString("N0")} 분 전";
                    }

                    return $"{diff.TotalHours.ToString("N0")} 시간 전";
                }

                return $"{diff.TotalDays.ToString("N0")} 일 전";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class WinConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value is bool win)
            {
                if (win)
                {
                    var color = (Color)ColorConverter.ConvertFromString("#FFFFEEEE");
                    return new SolidColorBrush(color);

                }
                else
                {
                    var color = (Color)ColorConverter.ConvertFromString("#FFD4E4FE");
                    return new SolidColorBrush(color);
                }
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class WinToStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value is bool win)
            {
                if (win)
                   return "승리";
                else
                    return "패배";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class KdaConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double Kda;

           if(double.TryParse(value.ToString() ,out Kda))
           {
                if(Kda < 2.0)
                {
                    return Brushes.LightGray;
                }
                else if (Kda < 3.0)
                {
                    return Brushes.Green;
                }
                else if (Kda < 4.0)
                {
                    return Brushes.Blue;
                }
                else
                {
                    return Brushes.Red;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}