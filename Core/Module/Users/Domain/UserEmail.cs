using Core.Module.Shared.Domain;

namespace Core.Module.Users.Domain
{
    public class UserEmail : Email
    {
        public UserEmail(string value) : base(value)
        {
            this.EnsureIsValid(value);
        }

        private void EnsureIsValid(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new InvalidUserEmailException();

            if (value.Length > 200)
                throw new InvalidUserEmailException();
        }
    }
}