using Cobalt.Extensions.DataRowExtensions;
using System.Data;
using Xunit;

namespace Cobalt.Tests.Extensions.DataRowExtensions
{
    public class AsBoolExtensionTests
    {
        private readonly DataTable DataTable;
        private const int FalseRowId = 0;
        private const int TrueRowId = 1;
        private const int MiscRowId = 2;
        private const string CharColumn = "CharColumn";
        private const string NumericColumn = "NumericColumn";
        private const string StringColumn = "StringColumn";

        public AsBoolExtensionTests()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(NumericColumn, typeof(int));
            DataTable.Columns.Add(CharColumn, typeof(char));
            DataTable.Columns.Add(StringColumn, typeof(string));

            DataTable.Rows.Add(0, 'F', "False");
            DataTable.Rows.Add(1, 'T', "True");
            DataTable.Rows.Add(2, 'H', "Hello");
        }

        [Fact]
        public void IsFalse_WhenCharIsF()
        {
            var sut = DataTable.Rows[FalseRowId];

            Assert.False(sut.AsBool(CharColumn));
        }

        [Fact]
        public void IsFalse_WhenCharNotFOrT()
        {
            var sut = DataTable.Rows[MiscRowId];

            Assert.False(sut.AsBool(CharColumn));
        }

        [Fact]
        public void IsFalse_WhenNumericalIs0()
        {
            var sut = DataTable.Rows[FalseRowId];

            Assert.False(sut.AsBool(NumericColumn));
        }

        [Fact]
        public void IsFalse_WhenNumericalNot0or1()
        {
            var sut = DataTable.Rows[MiscRowId];

            Assert.False(sut.AsBool(NumericColumn));
        }

        [Fact]
        public void IsFalse_WhenStringIsFalse()
        {
            var sut = DataTable.Rows[FalseRowId];

            Assert.False(sut.AsBool(StringColumn));
        }

        [Fact]
        public void IsFalse_WhenStringNotFalseOrTrue()
        {
            var sut = DataTable.Rows[MiscRowId];

            Assert.False(sut.AsBool(StringColumn));
        }

        [Fact]
        public void IsTrue_WhenCharIsT()
        {
            var sut = DataTable.Rows[TrueRowId];

            Assert.True(sut.AsBool(CharColumn));
        }

        [Fact]
        public void IsTrue_WhenNumericalIs1()
        {
            var sut = DataTable.Rows[TrueRowId];

            Assert.True(sut.AsBool(NumericColumn));
        }

        [Fact]
        public void IsTrue_WhenStringIsTrue()
        {
            var sut = DataTable.Rows[TrueRowId];

            Assert.True(sut.AsBool(StringColumn));
        }

    }
}
