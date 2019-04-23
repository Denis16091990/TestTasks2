﻿using System;
using System.Runtime.Serialization;

namespace СommunicationChannel.Abstraction
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException()
        {
        }

        public CommandHandlerNotFoundException(string message) : base(message)
        {
        }

        public CommandHandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommandHandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}