using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using System;
using Xunit;

namespace Test.Module.Users.Domain
{
    public class UserTest
    {
        [Fact]
        public void EmptyEmailShouldThrowException()
        {
            Assert.Throws<InvalidEmailException>(() => this.CreateUserWithEmail(""));
        }

        [Fact]
        public void InvalidEmailShouldThrowException()
        {
            Assert.Throws<InvalidEmailException>(() => this.CreateUserWithEmail("invalid@email@"));
        }

        private User CreateUserWithEmail(String email)
        {
            //ULL fem servie new User, no User.Create, per evitar crear un event de domini
            return new User(new UserId("1"), new UserName("testUser"), new UserEmail(email), new UserPassword("testPassword"));
        }


        /*[Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        public void CreateUserTestCase(int first, int second, int expectedResult)
        {
            var result = Add(first, second);

            Assert.Equal(expectedResult, result);
        }*/
    }
}
