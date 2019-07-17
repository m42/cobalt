using System;
using System.Text.RegularExpressions;

namespace Cobalt.Validators
{
    public static class EmailAddressValidator
    {
        /// <summary>
        /// Validates the format of an email address
        /// </summary>
        public static bool IsValid(string emailAddress)
        {
            if (String.IsNullOrEmpty(emailAddress))
                return false;

            var pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);
        }
    }
}
