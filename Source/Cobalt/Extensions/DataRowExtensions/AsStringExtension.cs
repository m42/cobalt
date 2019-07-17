using System.Data;

namespace Cobalt.Extensions.DataRowExtensions
{
    public static class AsStringExtension
    {
        public static string AsString(this DataRow dataRow, string columnName)
        {
            return dataRow[columnName].ToString();
        }
    }
}
