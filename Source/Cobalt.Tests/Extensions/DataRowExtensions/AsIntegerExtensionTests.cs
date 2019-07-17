using Cobalt.Extensions.DataRowExtensions;
using System.Data;
using Xunit;

namespace Cobalt.Tests.Extensions.DataRowExtensions
{
    public class AsIntegerExtensionTests
    {
        private readonly DataTable DataTable;
        private const int RowOneId = 0;
        private const string DoubleDownColumn = "DoubleDownColumn";
        private const string DoubleUpColumn = "DoubleUpColumn";
        private const string IntColumn = "IntColumn";
        private const string StringColumn = "StringColumn";
        private const string TextColumn = "TextColumn";

        public AsIntegerExtensionTests()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(DoubleDownColumn, typeof(double));
            DataTable.Columns.Add(DoubleUpColumn, typeof(double));
            DataTable.Columns.Add(IntColumn, typeof(int));
            DataTable.Columns.Add(StringColumn, typeof(string));
            DataTable.Columns.Add(TextColumn, typeof(string));

            DataTable.Rows.Add(3.14, 9.81, 7, "42", "Hello");
        }

        [Fact]
        public void IsEqual_WhenCorrectString()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(42, sut.AsInteger(StringColumn));
        }

        [Fact]
        public void IsEqual_WhenInt()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(7, sut.AsInteger(IntColumn));
        }

        [Fact]
        public void IsRoundedDown_WhenDoubleLessThanPointFive()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(3, sut.AsInteger(DoubleDownColumn));
        }

        [Fact]
        public void IsRoundedUp_WhenDoubleMoreThanPointFive()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(10, sut.AsInteger(DoubleUpColumn));
        }

        [Fact]
        public void IsZero_WhenIncorrectString()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(0, sut.AsInteger(TextColumn));
        }

    }
}
