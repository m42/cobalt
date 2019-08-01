using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobalt.Converters
{
    public class DataTableToHtmlTableConverter
    {
        private readonly DataTable DataTable;

        public DataTableToHtmlTableConverter(DataTable dataTable)
        {
            DataTable = dataTable;
        }

        public string Convert()
        {
            var result = new StringBuilder();

            result.AppendLine("<table class=\"table table-striped table-sm\" > ");
            result.Append(BuildHeader());
            result.AppendLine("<tbody>");

            foreach (DataRow row in DataTable.Rows)
            {
                result.AppendLine(" <tr>");

                foreach (DataColumn column in DataTable.Columns)
                {
                    result.Append("  <td>");
                    result.Append(row[column].ToString());
                    result.AppendLine("</td>");
                }

                result.AppendLine(" </tr>");
            }

            result.AppendLine("</tbody>");
            result.AppendLine("</table>");
            return result.ToString();
        }

        private string BuildHeader()
        {
            var header = new StringBuilder();

            header.AppendLine("<thead class=\"thead-dark\">");
            header.AppendLine(" <tr>");

            foreach (DataColumn column in DataTable.Columns)
            {
                header.Append("  <th>");
                header.Append(column.ToString());
                header.AppendLine("</th>");
            }

            header.AppendLine(" </tr>");
            header.AppendLine("</thead>");

            return header.ToString();
        }

    }
}
