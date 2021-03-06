using System.Text.RegularExpressions;

namespace Core.Module.Users.Domain
{
    public class UserName
    {
        public string value { get; }

        public UserName(string value)
        {
            this.EnsureIsValid(value);
            this.value = value;
        }

        private void EnsureIsValid(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new InvalidUserNameException();
            
            if(value.Length > 40)
                throw new InvalidUserNameException();

            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9-_]*$", RegexOptions.ECMAScript))
                throw new InvalidUserNameException();
        }
    }
}