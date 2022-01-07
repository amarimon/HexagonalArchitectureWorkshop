using Core.Module.Shared.Domain;

namespace Core.Module.Users.Domain
{
    public class Email
    {
        public string value { get;}

        public Email(string value)
        {
            this.EnsureIsValid(value);
            this.value = value;
        }

        private void EnsureIsValid(string value)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(value);
            }
            catch
            {
                throw new InvalidEmailException();
            }
        }
    }
}