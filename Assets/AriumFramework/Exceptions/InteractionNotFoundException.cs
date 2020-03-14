using System;

namespace AriumFramework.Exceptions
{
    public class InteractionNotFoundException : Exception
    {
        public InteractionNotFoundException(Type type) : base("Interaction " + type + " not specified or found")
        {
        }
    }
}