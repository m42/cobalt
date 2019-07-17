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
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(tag))
                return string.Empty;

            var result = string.Empty;

            if (content.ToLower().Contains(tag.ToLower()))
            {
                var startTag = $"<{tag}>";
                var endTag = $"</{tag}>";
                var startIndex = content.IndexOf(startTag) + startTag.Length;
                var length = content.IndexOf(endTag) - startIndex;

                result = content.Substring(startIndex, length);
            }

            return result;
        }
        
    }
}
