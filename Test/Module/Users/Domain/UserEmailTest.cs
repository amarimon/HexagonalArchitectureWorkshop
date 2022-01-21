using Core.Module.Users.Domain;
using Xunit;

namespace Test.Module.Users.Domain
{
    public class UserEmailTest
    {
        [Fact]
        public void EmptyUserEmailShouldThrowException()
        {
            Assert.Throws<InvalidUserEmailException>(() => new UserEmail(""));
        }

        [Fact]
        public void MalformedEmailShouldThrowException()
        {
            Assert.Throws<InvalidUserEmailException>(() => new UserEmail("test&%/.@@email.@email.?"));
        }

        [Fact]
        public void TooLargeUserEmailShouldThrowException()
        {
            Assert.Throws<InvalidUserEmailException>(() => new UserEmail("012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890@email.com"));
        }
    }
}
