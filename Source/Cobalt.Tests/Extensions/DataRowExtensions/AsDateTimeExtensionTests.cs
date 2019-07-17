using Cobalt.Extensions.DataRowExtensions;
using System;
using System.Data;
using Xunit;

namespace Cobalt.Tests.Extensions.DataRowExtensions
{
    public class AsDateTimeExtensionTests
    {
        private readonly DataTable DataTable;
        private const int RowOneId = 0;
        private const string DateTimeColumn = "DateTimeColumn";
        private const string DateColumn = "DateColumn";
        private const string StringColumn = "StringColumn";

        public AsDateTimeExtensionTests()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(DateTimeColumn, typeof(DateTime));
            DataTable.Columns.Add(DateColumn, typeof(DateTime));
            DataTable.Columns.Add(StringColumn, typeof(string));

            DataTable.Rows.Add("2018-07-14 19:20:21", "2018-07-14", "Hello World");
        }

        [Fact]
        public void Is111_WhenIncorrectString()
        {
            var expected = new DateTime(1, 1, 1);
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(expected, sut.AsDateTime(StringColumn));
        }

        [Fact]
        public void IsEqual_WhenCorrectDateString()
        {
            var expected = new DateTime(2018, 7, 14, 0, 0, 0);
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(expected, sut.AsDateTime(DateColumn));
        }

        [Fact]
        public void IsEqual_WhenCorrectDateTimeString()
        {
            var expected = new DateTime(2018, 7, 14, 19, 20, 21);
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal(expected, sut.AsDateTime(DateTimeColumn));
        }

    }
}
