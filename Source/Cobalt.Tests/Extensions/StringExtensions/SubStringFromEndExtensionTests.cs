using Cobalt.Extensions.StringExtensions;
using Xunit;

namespace Cobalt.Tests.Extensions.StringExtensions
{
    public class SubStringFromEndExtensionTests
    {
        [Fact]
        public void ReturnsCorrectString_WhenLessCharsThanStringLength()
        {
            var sut = "Hello World".SubStringFromEnd(5);
            Assert.Equal("World", sut);
        }

        [Fact]
        public void ReturnsWholeString_WhenMoreCharsThanStringLength()
        {
            var sut = "Hello World".SubStringFromEnd(50);
            Assert.Equal("Hello World", sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenZeroChars()
        {
            var sut = "Hello World".SubStringFromEnd(0);
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStringIsEmpty()
        {
            var sut = "".SubStringFromEnd(1);
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStringIsNull()
        {
            string nullString = null;
            var sut = nullString.SubStringFromEnd(1);
            Assert.Empty(sut);
        }
    }
}
