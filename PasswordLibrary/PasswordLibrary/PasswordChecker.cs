namespace PasswordLibrary
{
    public static class PasswordChecker
    {
        /// <summary>
        /// Evaluates the strength of a given password.
        /// The function checks length and character diversity (uppercase, lowercase, digits, symbols)
        /// and classifies the password as INELIGIBLE, WEAK, MEDIUM, or STRONG.
        /// </summary>
        /// <param name="password">The password string to evaluate.</param>
        /// <returns>
        /// Returns:
        /// - "INELIGIBLE" if the password is empty, null, or shorter than 8 characters.
        /// - "WEAK" if only one character type is present.
        /// - "MEDIUM" if two or three character types are present.
        /// - "STRONG" if all four character types are present.
        /// </returns>
        public static string CheckStrength(string password)
        {
            if (string.IsNullOrEmpty(password)) return "INELIGIBLE";

            if (password.Length < 8) return "INELIGIBLE";

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSymbol = password.Any(ch => !char.IsLetterOrDigit(ch));

            int criteriaMet = new[] { hasUpper, hasLower, hasDigit, hasSymbol }.Count(c => c);

            return criteriaMet switch
            {
                0 => "INELIGIBLE",
                1 => "WEAK",
                2 or 3 => "MEDIUM",
                4 => "STRONG",
                _ => "INELIGIBLE"
            };
        }
    }
}