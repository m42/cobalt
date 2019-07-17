namespace Cobalt.Extensions.StringExtensions
{
    public static class SubStringBetweenWordsExtension
    {
        /// <summary>
        /// Returns the string between the first occurance of two words
        /// </summary>
        public static string SubStringBetweenWords(this string source, string startWord, string endWord)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var result = string.Empty;

            if (source.Contains(startWord) && source.Contains(endWord))
            {
                var startIndex = source.IndexOf(startWord) + startWord.Length;
                var length = source.IndexOf(endWord) - startIndex;

                result = source.Substring(startIndex, length);
            }

            return result;
        }

    }
}
