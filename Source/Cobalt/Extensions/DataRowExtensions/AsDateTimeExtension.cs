using System;
using System.Data;

namespace Cobalt.Extensions.DataRowExtensions
{
    public static class AsDateTimeExtension
    {
        public static DateTime AsDateTime(this DataRow dr, string columnName)
        {
            DateTime.TryParse(dr.AsString(columnName), out DateTime value);
            return value;
        }
    }
}
