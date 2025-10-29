using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ProductMonitorControlLibrary.Resources.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string status)
        {
            return status switch
            {
                "作业中" => Brushes.LightGreen,
                "等待中" => Brushes.Orange,
                "故障中" => Brushes.PaleVioletRed,
                "停机中" => Brushes.LightGray,
                _ => Brushes.Transparent
            };
        }

        return Brushes.Transparent;
        throw new NotImplementedException();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}