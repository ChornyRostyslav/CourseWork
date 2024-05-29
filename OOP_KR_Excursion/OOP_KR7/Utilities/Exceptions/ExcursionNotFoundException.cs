namespace OOP_KR
{
    using System;

    public class ExcursionNotFoundException : Exception
    {
        public ExcursionNotFoundException(string message) : base(message) { }
    }
}