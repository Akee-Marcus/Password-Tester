namespace PasswordLibrary
{
    public static class PasswordChecker
    {
        public static string CheckStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "INELIGIBLE";

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