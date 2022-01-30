using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using Xunit;

namespace Test.Module.Users.Domain
{
    
    [Trait("Category", "Unit")]
    [Trait("Class", nameof(UserEmail))]
    [Trait("Method", nameof(UserEmail))]
    public class UserEmailTest
    {
        [Fact]
        public void EmptyUserEmailShouldThrowException()
        {
            Assert.Throws<InvalidEmailException>(() => new UserEmail(""));
        }

        [Fact]
        public void MalformedEmailShouldThrowException()
        {
            Assert.Throws<InvalidEmailException>(() => new UserEmail("test&%/.@@email.@email.?"));
        }

        [Fact]
        public void TooLargeUserEmailShouldThrowException()
        {
            Assert.Throws<InvalidUserEmailException>(() => new UserEmail("012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890@email.com"));
        }
    }
}
