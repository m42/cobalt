using Cobalt.Utils.TextUtils;
using System.Text;
using Xunit;

namespace Cobalt.Tests.Utils.TextUtils
{
    public class TagReaderTests
    {
        private static string GetContent()
        {
            var content = new StringBuilder();
            content.AppendLine("Just some ordinary text.");
            content.AppendLine("<tagA>Value A</tagA>");
            content.AppendLine("<tagB>Value B</tagB>");
            content.AppendLine("<tagA>Another tagA</tagA>");
            content.AppendLine("More ordinary text.");

            return content.ToString();
        }

        [Fact]
        public void GetTagValue_ReturnsCorrectValue_WhenCorrectInput()
        {
            var sutA = TagReader.GetTagValue(GetContent(), "tagA");
            var sutB = TagReader.GetTagValue(GetContent(), "tagB");

            Assert.Equal("Value A", sutA);
            Assert.Equal("Value B", sutB);
        }

        [Fact]
        public void GetTagValue_ReturnsEmpty_WhenContentIsNull()
        {
            var sut = TagReader.GetTagValue(null, "tagA");

            Assert.Equal(string.Empty, sut);
        }

        [Fact]
        public void GetTagValue_ReturnsEmpty_WhenContentIsEmpty()
        {
            var sut = TagReader.GetTagValue(string.Empty, "tagA");

            Assert.Equal(string.Empty, sut);
        }

        [Fact]
        public void GetTagValue_ReturnsEmpty_WhenTagIsNull()
        {
            var sut = TagReader.GetTagValue(GetContent(), null);

            Assert.Equal(string.Empty, sut);
        }

        [Fact]
        public void GetTagValue_ReturnsEmpty_WhenTagIsEmpty()
        {
            var sut = TagReader.GetTagValue(GetContent(), string.Empty);

            Assert.Equal(string.Empty, sut);
        }
    }
}
