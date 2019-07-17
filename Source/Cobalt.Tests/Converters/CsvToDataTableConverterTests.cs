using Cobalt.Converters;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace Cobalt.Tests.Converters
{
    public class CsvToDataTableConverterTests
    {
        private const string TestFile = "Converters/CsvToDataTableConverterTestFile.csv";
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
        public void ConvertFromFile_HasCorrectHeaders()
        {
            var converter = new CSVtoDataTableConverter();
            var sut = converter.ConvertFromFile(TestFile);

            Assert.Equal(3, sut.Columns.Count);

            Assert.Equal("Column A", sut.Columns[0].Caption.ToString());
            Assert.Equal("Column B", sut.Columns[1].Caption.ToString());
            Assert.Equal("Column C", sut.Columns[2].Caption.ToString());
        }

        [Fact]
        public void ConvertFromFile_HasCorrectRows()
        {
            var converter = new CSVtoDataTableConverter();
            var sut = converter.ConvertFromFile(TestFile);

            Assert.Equal(2, sut.Rows.Count);

            Assert.Equal("Value A1", sut.Rows[0][0].ToString());
            Assert.Equal("Value B1", sut.Rows[0][1].ToString());
            Assert.Equal("Value C1", sut.Rows[0][2].ToString());

            Assert.Equal("Value A2", sut.Rows[1][0].ToString());
            Assert.Equal("Value B2", sut.Rows[1][1].ToString());
            Assert.Equal("Value C2", sut.Rows[1][2].ToString());
        }

        [Fact]
        public void ConvertFromFile_ThrowsFileNotFoundException_WhenFileNotExists()
        {
            var converter = new CSVtoDataTableConverter();

            var sut = Assert.Throws<FileNotFoundException>(
               () => converter.ConvertFromFile(@"C:\NonExistingFile.ext"));
        }

        [Fact]
        public void ConvertFromFileContent_HasCorrectHeaders()
        {
            var converter = new CSVtoDataTableConverter();
            var sut = converter.ConvertFromFileContent(TestString);

            Assert.Equal(2, sut.Columns.Count);

            Assert.Equal("Header 1", sut.Columns[0].Caption.ToString());
            Assert.Equal("Header 2", sut.Columns[1].Caption.ToString());
        }

        [Fact]
        public void ConvertFromFileContent_HasCorrectRows()
        {
            var converter = new CSVtoDataTableConverter();
            var sut = converter.ConvertFromFileContent(TestString);

            Assert.Equal(2, sut.Rows.Count);

            Assert.Equal("The Value A1", sut.Rows[0][0].ToString());
            Assert.Equal("The Value B1", sut.Rows[0][1].ToString());

            Assert.Equal("The Value A2", sut.Rows[1][0].ToString());
            Assert.Equal("The Value B2", sut.Rows[1][1].ToString());
        }

        [Fact]
        public void ConvertFromFileContent_ThrowsArgumentNullException_WhenContentIsNull()
        {
            var converter = new CSVtoDataTableConverter();

            var sut = Assert.Throws<ArgumentNullException>(
               () => converter.ConvertFromFileContent(null));

            Assert.Equal("content", sut.ParamName);
        }

        [Fact]
        public void ConvertFromFileContent_ThrowsArgumentNullException_WhenContentIsEmpty()
        {
            var converter = new CSVtoDataTableConverter();

            var sut = Assert.Throws<ArgumentNullException>(
               () => converter.ConvertFromFileContent(string.Empty));

            Assert.Equal("content", sut.ParamName);
        }

    }
}
