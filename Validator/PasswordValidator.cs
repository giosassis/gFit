using System;
using System.Text.RegularExpressions;

namespace gFit.Validator
{
    public static class PasswordValidator
    {
        public static bool Validate(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            if (!hasNumber.IsMatch(password))
                return false;

            if (!hasUpperChar.IsMatch(password))
                return false;

            if (!hasLowerChar.IsMatch(password))
                return false;

            if (!hasSymbols.IsMatch(password))
                return false;

            return true;
        }
    }
}

