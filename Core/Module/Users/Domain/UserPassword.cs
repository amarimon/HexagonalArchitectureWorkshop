namespace Core.Module.Users.Domain
{
    public class UserPassword
    {
        public string value { get; }

        public UserPassword(string value)
        {
            this.EnsureIsValid(value);
            this.value = value;
        }

        private void EnsureIsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidUserNameException();

            if (value.Length > 20)
                throw new InvalidUserNameException();

            //TODO : Password strength validation
        }
    }
}