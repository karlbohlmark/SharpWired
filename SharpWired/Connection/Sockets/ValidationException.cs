using System;
using System.Runtime.Serialization;

namespace SharpWired.Connection.Sockets {
    /// <summary>Exception raised when serialization fails</summary>
    [Serializable]
    public class ValidationException : Exception {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        /// <summary>Constructor- Empty</summary>
        public ValidationException() {}

        /// <summary>Constructor with a message</summary>
        /// <param name="message"></param>
        public ValidationException(string message) : base(message) {}

        /// <summary>Constructor with a message an inner exception</summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ValidationException(string message, Exception inner) : base(message, inner) {}

        /// <summary>Protected constructor</summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ValidationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {}
    }
}