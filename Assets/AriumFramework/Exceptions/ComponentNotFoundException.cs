using System;

namespace AriumFramework.Exceptions
{
    public class ComponentNotFoundException : Exception
    {
        public ComponentNotFoundException(GameObjectWrapper gameObjectWrapper, Type type) : base(type + " component not found in " + gameObjectWrapper)
        {
        }
    }
}