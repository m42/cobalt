using System;

namespace Cobalt.Extensions.StringExtensions
{
    public static class SubStringFromStartExtension
    {
        /// <summary>
        /// Return a substring form the start of a string
        /// </summary>
        public static string SubStringFromStart(this string source, int numberOfCharacters)
        {
            if (String.IsNullOrEmpty(source))
                return string.Empty;

            if (numberOfCharacters >= source.Length)
                return source;

            return source.Substring(0, numberOfCharacters);
        }

    }
}
