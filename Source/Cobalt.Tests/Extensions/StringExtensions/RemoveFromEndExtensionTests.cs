using Cobalt.Extensions.StringExtensions;
using Xunit;

namespace Cobalt.Tests.Extensions.StringExtensions
{
    public class RemoveFromEndExtensionTests
    {
        [Fact]
        public void ReturnsCorrectString_WhenLessCharsThanTextLength()
        {
            var sut = "My string 123".RemoveFromEnd(4);
            Assert.Equal("My string", sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenMoreCharsThanTextLength()
        {
            var sut = "My string 123".RemoveFromEnd(40);
            Assert.Equal(string.Empty, sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStringIsNull()
        {
            string nullString = null;
            var sut = nullString.RemoveFromEnd(40);
            Assert.Equal(string.Empty, sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStringIsEmpty()
        {
            string emptyString = string.Empty;
            var sut = emptyString.RemoveFromEnd(40);
            Assert.Equal(string.Empty, sut);
        }
    }
}
