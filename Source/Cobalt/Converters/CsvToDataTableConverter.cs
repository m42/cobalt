using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Cobalt.Converters
{
    public class CSVtoDataTableConverter
    {
        private readonly string Content;

        public CSVtoDataTableConverter(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException(nameof(content));

            Content = content;
        }

        public DataTable Convert()
        {
            char[] separators = { ',', ';' };

            var dataTable = new DataTable();
            var lines = Regex.Split(Content, "\r\n");

            var headerRow = lines[0];
            var headers = headerRow.Split(separators);

            foreach (var header in headers)
            {
                dataTable.Columns.Add(header);
            }

            var numberOfColumns = headers.Length;

            for (int l = 1; l < lines.Length; l++)
            {
                if (string.IsNullOrEmpty(lines[l]))
                    continue;

                var row = lines[l];
                var columns = row.Split(separators);
                var dataRow = dataTable.NewRow();

                for (int i = 0; i < numberOfColumns; i++)
                {
                    dataRow[i] = columns[i];
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        
    }
}
