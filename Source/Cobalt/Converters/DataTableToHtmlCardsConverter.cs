using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobalt.Converters
{
    public class DataTableToHtmlCardsConverter
    {
        private readonly DataTable DataTable;

        public DataTableToHtmlCardsConverter(DataTable dataTable)
        {
            DataTable = dataTable;
        }

        public string Convert()
        {
            var result = new StringBuilder();

            result.AppendLine("<div class=\"card-columns\">");

            foreach (DataRow row in DataTable.Rows)
            {
                result.AppendLine("<div class=\"card border-dark\" style=\"max-width: 18rem;\">");

                //result.Append(" <img src=\"https://picsum.photos/200\" class=\"card-img-top\">");

                result.Append(" <div class=\"card-header\">");
                result.Append(row[0].ToString());
                result.AppendLine("</div>");

                result.AppendLine(" <div class=\"card-body text-dark\">");

                result.Append("  <h5 class=\"card-title\">");
                result.Append(row[1].ToString());
                result.AppendLine("</h5>");

                result.AppendLine("  <p class=\"card-text\">");

                for (int i = 2; i < DataTable.Columns.Count; i++)
                {
                    //result.Append("  <p class=\"card-text\">");
                    result.AppendLine($"  {DataTable.Columns[i].ToString()}: {row[i].ToString()}<br />");
                    //result.Append("  </p>");
                }

                result.AppendLine("  </p>");

                result.AppendLine(" </div>");
                result.AppendLine("</div>");
                result.AppendLine();
            }
            result.AppendLine("</div>");
            return result.ToString();
        }


        public string ConvertToNonResponsiveDeck()
        {
            var result = new StringBuilder();

            result.AppendLine("<div class=\"card-deck\">");

            foreach (DataRow row in DataTable.Rows)
            {
                result.AppendLine(" <div class=\"card\">");
                result.AppendLine("  <div class=\"card-body\">");

                result.Append("   <h5 class=\"card-title\">");
                result.Append(row[0].ToString());
                result.Append("   </h5>");

                for (int i = 1; i < DataTable.Columns.Count; i++)
                {
                    result.Append("   <p class=\"card-text\">");
                    result.Append($"{DataTable.Columns[i].ToString()}: {row[i].ToString()}");
                    result.Append("   </p>");
                }

                result.AppendLine("  </div>");
                result.AppendLine(" </div>");
            }

            result.AppendLine("</div>");
            return result.ToString();
        }

    }
}
