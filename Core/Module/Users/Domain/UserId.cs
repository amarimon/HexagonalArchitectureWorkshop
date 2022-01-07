
using System;

namespace Core.Module.Users.Domain
{
    sealed public class UserId
    {
        //public string value { get; }
        public long value { get; }

        public UserId(string value)
        {
            this.value = this.EnsureIsValid(value);
        }

        private long EnsureIsValid(string value)
        {
            try
            {
                return long.Parse(value);
            }
            catch
            {
                throw new InvalidUserIdException();
            }
        }

        /*private void EnsureIsValid(string value)
        {
            try
            {
                Guid.Parse(value);
            }
            catch
            {
                throw new InvalidUserIdException();
            }
        }*/
    }
}
