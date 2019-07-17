using System;

namespace Cobalt.Extensions.StringExtensions
{
    public static class SubStringFromEndExtension
    {
        /// <summary>
        /// Return a substring form the end of a string
        /// </summary>
        public static string SubStringFromEnd(this string source, int numberOfCharacters)
        {
            if (String.IsNullOrEmpty(source))
                return string.Empty;

            if (numberOfCharacters >= source.Length)
                return source;

            return source.Substring(source.Length - numberOfCharacters);
        }

    }
}
