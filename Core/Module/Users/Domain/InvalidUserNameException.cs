using System;
using System.Runtime.Serialization;

namespace Core.Module.Users.Domain
{
    [Serializable]
    public class InvalidUserNameException : Exception
    {
        public InvalidUserNameException()
        {
        }

        public InvalidUserNameException(string message) : base(message)
        {
        }

        public InvalidUserNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUserNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}