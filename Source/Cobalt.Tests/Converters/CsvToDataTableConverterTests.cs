using Cobalt.Converters;
using System;
using System.Text;
using Xunit;

namespace Cobalt.Tests.Converters
{
    public class CsvToDataTableConverterTests
    {
        private static string TestString;

        public CsvToDataTableConverterTests()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Header 1,Header 2");
            sb.AppendLine("The Value A1,The Value B1");
            sb.AppendLine("The Value A2,The Value B2");

            TestString = sb.ToString();
        }

        [Fact]
        public void ConvertFromFileContent_HasCorrectHeaders()
        {
            var converter = new CSVtoDataTableConverter(TestString);
            var sut = converter.Convert();

            Assert.Equal(2, sut.Columns.Count);

            Assert.Equal("Header 1", sut.Columns[0].Caption.ToString());
            Assert.Equal("Header 2", sut.Columns[1].Caption.ToString());
        }

        [Fact]
        public void ConvertFromFileContent_HasCorrectRows()
        {
            var converter = new CSVtoDataTableConverter(TestString);
            var sut = converter.Convert();

            Assert.Equal(2, sut.Rows.Count);

            Assert.Equal("The Value A1", sut.Rows[0][0].ToString());
            Assert.Equal("The Value B1", sut.Rows[0][1].ToString());

            Assert.Equal("The Value A2", sut.Rows[1][0].ToString());
            Assert.Equal("The Value B2", sut.Rows[1][1].ToString());
        }

        [Fact]
        public void ConvertFromFileContent_ThrowsArgumentNullException_WhenContentIsNull()
        {
            var sut = Assert.Throws<ArgumentNullException>(
               () => new CSVtoDataTableConverter(null));

            Assert.Equal("content", sut.ParamName);
        }

        [Fact]
        public void ConvertFromFileContent_ThrowsArgumentNullException_WhenContentIsEmpty()
        {
            var sut = Assert.Throws<ArgumentNullException>(
               () => new CSVtoDataTableConverter(string.Empty));

            Assert.Equal("content", sut.ParamName);
        }

    }
}
