using PasswordLibrary;
using Xunit;

namespace PasswordLibrary.Tests
{
    public class PasswordCheckerTester
    {
        [Fact]
        public void LessThan8_Ineligible()
        {
            Assert.Equal("INELIGIBLE", PasswordChecker.CheckStrength("Pass05!"));
        }

        [Fact]
        public void MoreThan8_Eligible()
        {
            Assert.Equal("MEDIUM", PasswordChecker.CheckStrength("$teveWasHere"));
        }

        [Fact]
        public void EmptyPassword_ReturnsIneligible()
        {
            Assert.Equal("INELIGIBLE", PasswordChecker.CheckStrength(""));
        }

        [Fact]
        public void OnlyUpperCase_ReturnsWeak()
        {
            Assert.Equal("WEAK", PasswordChecker.CheckStrength("BAHBAHBAH"));
        }

        [Fact]
        public void OnlyLowerCase_ReturnsWeak()
        {
            Assert.Equal("WEAK", PasswordChecker.CheckStrength("password"));
        }

        [Fact]
        public void OnlyDigits_ReturnsWeak()
        {
            Assert.Equal("WEAK", PasswordChecker.CheckStrength("12345678"));
        }

        [Fact]
        public void OnlySymbols_ReturnsWeak()
        {
            Assert.Equal("WEAK", PasswordChecker.CheckStrength("@#%$%$$*@"));
        }

        [Fact]
        public void UpperAndLower_ReturnsMedium()
        {
            Assert.Equal("MEDIUM", PasswordChecker.CheckStrength("Password"));
        }

        [Fact]
        public void LowerAndDigit_ReturnsMedium()
        {
            Assert.Equal("MEDIUM", PasswordChecker.CheckStrength("notpassword278"));
        }

        [Fact]
        public void UpperLowerAndDigit_ReturnsMedium()
        {
            Assert.Equal("MEDIUM", PasswordChecker.CheckStrength("Maybepassword190"));
        }

        [Fact]
        public void AllCriteria_ReturnsStrong()
        {
            Assert.Equal("STRONG", PasswordChecker.CheckStrength("GoodPassword05!"));
        }
    }
}