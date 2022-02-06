using Core.Module.Users.Application;
using System.Collections;
using System.Collections.Generic;

namespace Test.Module.Users.Application
{
    internal class CreateInvalidUserRequestGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new CreateUserRequest("1234", "amarimon", "", "@password") },
            new object[] { new CreateUserRequest("1234", "amarimon", "012345678900123456789001234567890012345678900123456789001234567890", "@password") },
            new object[] { new CreateUserRequest("1234", "amarimon", "user name", "@password") },
            //new object[] { new CreateUserRequest("1234", "amarimon", "amarimon@cloudactivereception.com", "@password") },
            new object[] { new CreateUserRequest("1234", "amarimon", "", "@password") },
            new object[] { new CreateUserRequest("1234", "amarimon", "test&%/.@@email.@email.?", "@password") },
            new object[] { new CreateUserRequest("1234", "amarimon", "012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890@email.com", "@password") }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}