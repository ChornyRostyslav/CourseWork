namespace OOP_KR
{
    using System;

    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message) : base(message) { }
    }
}