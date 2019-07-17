using Cobalt.Extensions.StringExtensions;
using Xunit;

namespace Cobalt.Tests.Extensions.StringExtensions
{
    public class SubStringFromStartExtensionTests
    {
        [Fact]
        public void ReturnsCorrectString_WhenLessCharsThanStringLength()
        {
            var sut = "Hello World".SubStringFromStart(5);
            Assert.Equal("Hello", sut);
        }

        [Fact]
        public void ReturnsWholeString_WhenMoreCharsThanStringLength()
        {
            var sut = "Hello World".SubStringFromStart(50);
            Assert.Equal("Hello World", sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenZeroChars()
        {
            var sut = "Hello World".SubStringFromStart(0);
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStringIsEmpty()
        {
            var sut = "".SubStringFromStart(1);
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStringIsNull()
        {
            string nullString = null;
            var sut = nullString.SubStringFromStart(1);
            Assert.Empty(sut);
        }
    }
}
