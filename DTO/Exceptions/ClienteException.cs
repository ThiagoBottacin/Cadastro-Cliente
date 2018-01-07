using System;

namespace DTO.Exceptions
{
    [Serializable]
    public class ClienteException : Exception
    {
        public ClienteException() : base() { }
        public ClienteException(string message) : base(message) { }
        public ClienteException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ClienteException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
