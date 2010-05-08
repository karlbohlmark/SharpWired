using System;

namespace SharpWired {
    public class SingletonException : Exception {
        public SingletonException(string message) : base(message) {}
    }
}