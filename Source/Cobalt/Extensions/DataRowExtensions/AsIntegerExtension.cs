using System;
using System.Data;

namespace Cobalt.Extensions.DataRowExtensions
{
    public static class AsIntegerExtension
    {
        public static int AsInteger(this DataRow dataRow, string columnName)
        {
            var isDouble = double.TryParse(dataRow.AsString(columnName), out double doubleValue);
            var isInt = int.TryParse(dataRow.AsString(columnName), out int value);

            if (isDouble && !isInt)
            {
                try
                {
                    value = Convert.ToInt32(doubleValue);
                }
                catch(Exception)
                {
                    // do nothing
                }
            }

            return value;
        }
    }
}
