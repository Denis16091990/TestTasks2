using System;

namespace Camera.Domain.Abstractions
{
    public class CameraDomainException : Exception
    {
        public CameraDomainException()
        { }

        public CameraDomainException(string message)
            : base(message)
        { }

        public CameraDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
