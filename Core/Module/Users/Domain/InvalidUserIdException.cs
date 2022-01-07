﻿using System;
using System.Runtime.Serialization;

namespace Core.Module.Users.Domain
{
    [Serializable]
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException()
        {
        }

        public InvalidUserIdException(string message) : base(message)
        {
        }

        public InvalidUserIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUserIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}