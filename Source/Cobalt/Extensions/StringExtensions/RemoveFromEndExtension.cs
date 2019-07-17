namespace Cobalt.Extensions.StringExtensions
{
    public static class RemoveFromEndExtension
    {
        /// <summary>
        /// Returns a new string with specified number of characters from end deleted from current string.
        /// </summary>
        public static string RemoveFromEnd(this string source, int numberOfCharacters)
        {
            if (string.IsNullOrEmpty(source) || numberOfCharacters >= source.Length)
                return string.Empty;

            return source.Remove(source.Length - numberOfCharacters);
        }
    }
}
