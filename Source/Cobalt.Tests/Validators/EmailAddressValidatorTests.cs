using Cobalt.Validators;
using Xunit;

namespace Cobalt.Tests.Validators
{
    public class EmailAddressValidatorTests
    {
        [Theory]
        [InlineData("name@mail.net")]
        [InlineData("firstname.lastname-last_name@mail.co.uk")]
        [InlineData("123@mail.domain.otherdomain.net")]
        public void IsTrue_WhenEmailIsCorrect(string emailAddress)
        {
            Assert.True(EmailAddressValidator.IsValid(emailAddress));
        }

        [Theory]
        [InlineData("name@mail,net")]
        [InlineData("name@mail")]
        [InlineData("namemail.net")]
        [InlineData("123@mail.net.")]
        [InlineData("")]
        [InlineData(null)]
        public void IsFalse_WhenEmailIsIncorrect(string emailAddress)
        {
            Assert.False(EmailAddressValidator.IsValid(emailAddress));
        }

    }
}
