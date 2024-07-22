using System.Globalization;

namespace XmlToZpl.Utils
{
    public static class PointsConverter
    {
        private const double CmToInch = 0.393701;
        private const int Dpi = 203;
        public static int ConvertDimension(string dimensionValue)
        {
            return (int)(double.TryParse(dimensionValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double val) ? val * CmToInch * Dpi : 0);
        }
    }
}