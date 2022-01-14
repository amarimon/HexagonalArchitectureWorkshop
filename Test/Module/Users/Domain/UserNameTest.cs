using Core.Module.Users.Domain;
using Xunit;

namespace Test.Module.Users.Domain
{
    public class UserNameTest
    {
        [Fact]
        public void EmptyUserNameShouldThrowException()
        {
            Assert.Throws<InvalidUserNameException>(() => new UserName(""));
        }

        //[Fact(Skip = "WTF! Length is valid!")]
        [Fact]
        public void TooLargeUserNameShouldThrowException()
        {
            Assert.Throws<InvalidUserNameException>(() => new UserName("012345678900123456789001234567890012345678900123456789001234567890"));
        }
    }
}
