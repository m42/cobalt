using System.Data;

namespace Cobalt.Extensions.DataRowExtensions
{
    public static class AsDoubleExtension
    {
        public static double AsDouble(this DataRow dataRow, string columnName, bool replaceDotWithComma = false)
        {
            var valueToParse = dataRow.AsString(columnName);

            if (replaceDotWithComma)
                valueToParse = valueToParse.Replace(".", ",");

            double.TryParse(valueToParse, out double value);

            return value;
        }
    }
}
