using Core.Module.Shared.Domain;
using System;
using System.Runtime.Serialization;

namespace Core.Module.Users.Domain
{
    [Serializable]
    public class InvalidUserNameException : DomainException
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