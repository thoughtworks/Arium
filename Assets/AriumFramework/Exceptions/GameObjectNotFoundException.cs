using System;

namespace AriumFramework.Exceptions
{
    public class GameObjectNotFoundException : Exception
    {
        public GameObjectNotFoundException(string gameObjectName) : base("GameObject " + gameObjectName + " not found")
        {
        }
    }
}