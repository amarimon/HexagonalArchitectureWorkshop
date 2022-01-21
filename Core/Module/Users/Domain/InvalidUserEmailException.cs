using System;
using System.Runtime.Serialization;

namespace Core.Module.Users.Domain
{
    [Serializable]
    public class InvalidUserEmailException : Exception
    {
        public InvalidUserEmailException()
        {
        }

        public InvalidUserEmailException(string message) : base(message)
        {
        }

        public InvalidUserEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUserEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}