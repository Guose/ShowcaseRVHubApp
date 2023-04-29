using System.Globalization;

namespace ShowcaseRVHub.MAUI.ViewModel.ViewModelHelpers
{
    public class TwoValuesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var firstValue = values[0];
            var secondValue = values[1];

            return new {FirstValue = firstValue, SecondValue = secondValue};
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
