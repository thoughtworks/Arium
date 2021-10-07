using System;

namespace AriumFramework.Exceptions
{
    public class NullGameObjectException : Exception
    {
        public NullGameObjectException() : base("GameObject provided is null")
        {
        }
    }
}