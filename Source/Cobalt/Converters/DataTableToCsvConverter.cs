using System.Data;
using System.Text;

namespace Cobalt.Converters
{
    public class DataTableToCsvConverter
    {
        private readonly DataTable DataTable;
        private string ColumnDelimiter = ";";
        private bool UseHeader = true;
        private bool QuotationDelimitedValues = false;

        public DataTableToCsvConverter(DataTable dataTable)
        {
            DataTable = dataTable;
        }

        public string Convert()
        {
            var result = new StringBuilder();
            int columnCount = 0;

            if (UseHeader)
                result.Append(BuildHeader());

            foreach (DataRow row in DataTable.Rows)
            {
                foreach (DataColumn column in DataTable.Columns)
                {
                    AddValue(result, row[column].ToString());
                    AddDelimiter(result, ++columnCount);
                }

                result.AppendLine();
                columnCount = 0;
            }

            return result.ToString();
        }

        private string BuildHeader()
        {
            var header = new StringBuilder();
            int columnCount = 0;

            foreach (DataColumn column in DataTable.Columns)
            {
                AddValue(header, column.ToString());
                AddDelimiter(header, ++columnCount);
            }

            header.AppendLine();
            return header.ToString();
        }

        private void AddDelimiter(StringBuilder stringBuilder, int columnCount)
        {
            if (columnCount < DataTable.Columns.Count)
            {
                stringBuilder.Append(ColumnDelimiter);
            }
        }

        private void AddValue(StringBuilder stringBuilder, string value)
        {
            var quote = "\"";

            if (QuotationDelimitedValues)
                stringBuilder.Append(quote);

            stringBuilder.Append(value);

            if (QuotationDelimitedValues)
                stringBuilder.Append(quote);
        }

        public DataTableToCsvConverter WithColumnDelimiter(string columnDelimiter = ";")
        {
            ColumnDelimiter = columnDelimiter;
            return this;
        }

        public DataTableToCsvConverter WithHeader(bool useHeader = true)
        {
            UseHeader = useHeader;
            return this;
        }

        public DataTableToCsvConverter WithQuotationDelimitedValues(bool quotationDelimitedValues = false)
        {
            QuotationDelimitedValues = quotationDelimitedValues;
            return this;
        }

    }
}
