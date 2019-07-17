using Cobalt.Extensions.StringExtensions;
using Xunit;

namespace Cobalt.Tests.Extensions.StringExtensions
{
    public class SubStringBetweenWordsExtensionTests
    {
        [Fact]
        public void ReturnsCorrectString_WhenCorrectInput()
        {
            var sut = "Lorem ipsum %startWord% dolor sit amet %endWord% consectetur adipiscing elit"
                .SubStringBetweenWords("%startWord%", "%endWord%");
            Assert.Equal(" dolor sit amet ", sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenStartWordNotExists()
        {
            var sut = "Lorem ipsum dolor sit amet %endWord% consectetur adipiscing elit"
                .SubStringBetweenWords("%startWord%", "%endWord%");
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenEndWordNotExists()
        {
            var sut = "Lorem ipsum %startWord% dolor sit amet consectetur adipiscing elit"
                .SubStringBetweenWords("%startWord%", "%endWord%");
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenSourceIsNull()
        {
            string nullString = null;
            var sut = nullString.SubStringBetweenWords("%startWord%", "%endWord%");
            Assert.Empty(sut);
        }

        [Fact]
        public void ReturnsEmpty_WhenSourceIsEmpty()
        {
            string emptyString = string.Empty;
            var sut = emptyString.SubStringBetweenWords("%startWord%", "%endWord%");
            Assert.Empty(sut);
        }

    }
}
