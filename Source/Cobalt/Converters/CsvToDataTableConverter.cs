using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Cobalt.Converters
{
    public class CSVtoDataTableConverter
    {
        public DataTable ConvertFromFile(string filePath)
        {
            var content = File.ReadAllText(filePath);

            return ConvertFromFileContent(content);
        }

        public DataTable ConvertFromFileContent(string content)
        {
            if (String.IsNullOrEmpty(content))
                throw new ArgumentNullException(nameof(content));

            char[] separators = { ',', ';' };

            var dataTable = new DataTable();
            var lines = Regex.Split(content, "\r\n");

            var headerRow = lines[0];
            var headers = headerRow.Split(separators);

            foreach (var header in headers)
            {
                dataTable.Columns.Add(header);
            }

            var numberOfColumns = headers.Length;

            for (int l = 1; l < lines.Length; l++)
            {
                if (String.IsNullOrEmpty(lines[l]))
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
