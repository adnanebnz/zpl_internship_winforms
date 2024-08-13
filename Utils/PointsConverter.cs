using System;
using System.Globalization;

namespace XmlToZpl.Utils
{
    public static class PointsConverter
    {
        private const double CmToInch = 0.393701;
        public static int ConvertDimension(string dimensionValue, int dpi)
        {
            try
            {
                return (int)(double.TryParse(dimensionValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double val) ? val * CmToInch * dpi : 0);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}