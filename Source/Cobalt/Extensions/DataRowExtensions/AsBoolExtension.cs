using System.Data;
using System.Linq;

namespace Cobalt.Extensions.DataRowExtensions
{
    public static class AsBoolExtension
    {
        public static bool AsBool(this DataRow dataRow, string columnName)
        {
            var isTrue = new string[] { "1", "t", "true" };

            var value = dataRow.AsString(columnName).ToLower();

            return isTrue.Contains(value) ? true : false;
        }
    }
}
