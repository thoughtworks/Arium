using System;
using UnityEngine;

namespace AriumFramework.Exceptions
{
    public class ComponentNotFoundException : Exception
    {
        public ComponentNotFoundException(GameObject gameObject, Type type) : base(
            type + " component not found in " + gameObject.name)
        {
        }
    }
}