using Cobalt.Extensions.StringExtensions;

namespace Cobalt.Utils.TextUtils
{
    public partial class TagReader
    {
        /// <summary>
        /// Get value between start/endtag in a string.
        /// If multiple tags of same type, only value of the first is returned.
        /// </summary>
        /// <param name="content">The string</param>
        /// <param name="tag">The tag to look for</param>
        /// <returns>Value in tag</returns>
        public static string GetTagValue(string content, string tag)
        {
            return content.SubStringBetweenWords($"<{tag}>", $"</{tag}>");
        }
        
    }
}
