using Cobalt.Extensions.DataRowExtensions;
using System;
using System.Data;
using Xunit;

namespace Cobalt.Tests.Extensions.DataRowExtensions
{
    public class AsStringExtensionTests
    {
        private readonly DataTable DataTable;
        private const int RowOneId = 0;
        private const string StringColumn = "StringColumn";

        public AsStringExtensionTests()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(StringColumn, typeof(string));

            DataTable.Rows.Add("Hello World");
        }

        [Fact]
        public void IsEqual_WhenString()
        {
            var sut = DataTable.Rows[RowOneId];

            Assert.Equal("Hello World", sut.AsString(StringColumn));
        }

    }
}
