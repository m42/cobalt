using Cobalt.Extensions.DataRowExtensions;
using System.Data;
using Xunit;

namespace Cobalt.Tests.Extensions.DataRowExtensions
{
    public class AsDoubleExtensionTests
    {
        private readonly DataTable DataTable;
        private const int RowOneId = 0;
        private const string DoubleColumn = "DoubleColumn";
        private const string IntColumn = "IntColumn";
        private const string StringColumnWithPoint = "StringColumnWithPoint";
        private const string StringColumnWithComma = "StringColumnWithComma";
        private const string TextColumn = "TextColumn";

        public AsDoubleExtensionTests()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(DoubleColumn, typeof(double));
            DataTable.Columns.Add(IntColumn, typeof(int));
            DataTable.Columns.Add(StringColumnWithPoint, typeof(string));
            DataTable.Columns.Add(StringColumnWithComma, typeof(string));
            DataTable.Columns.Add(TextColumn, typeof(string));

            DataTable.Rows.Add(3.14, 7, "9.81", "1,618", "Hello");
        }

        [Fact]
        public void IsEqual_WhenDouble()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(3.14, sut.AsDouble(DoubleColumn));
        }

        [Fact]
        public void IsEqual_WhenInt()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(7, sut.AsDouble(IntColumn));
        }

        [Fact]
        public void IsEqual_WhenStringWithComma()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(1.618, sut.AsDouble(StringColumnWithComma));
        }

        [Fact]
        public void IsEqual_WhenStringWithPointAndReplace()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(9.81, sut.AsDouble(StringColumnWithPoint, true));
        }

        [Fact]
        public void IsZero_WhenIncorrectString()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(0, sut.AsDouble(TextColumn));
        }

    }
}
