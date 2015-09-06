using System;

namespace Task1
{
    class ComputersCompatibilityException : Exception
    {
        public ComputersCompatibilityException() : base() { }

        public ComputersCompatibilityException(string message) : base(message) { }
    }
}
