using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridSample
{
    public class CellStyleConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var rowType = ((value as DataGridIndentCell)?.Parent as DataGridRow)?.DataRow?.RowType.ToString();
            if(rowType == "HeaderRow")
            {
                return Colors.Coral;
            }
            else if(rowType == "CaptionCoveredRow")
            {
                return Colors.SteelBlue;
            }
            else
            {
                return Colors.PowderBlue;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
           return null;
        }
    }
}
