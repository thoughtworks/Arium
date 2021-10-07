using AriumFramework.Exceptions;
using UnityEngine;
using UnityEngine.Events;

namespace AriumFramework
{
    public abstract class Interaction<T> : IInteraction
    {
        private UnityAction<T> _action;

        protected Interaction(UnityAction<T> action)
        {
            _action = action;
        }
        
        protected Interaction()
        {
        }

        protected void SetAction(UnityAction<T> action)
        {
            _action = action;
        }

        public void PerformAction(GameObject gameObject)
        {
            var components = gameObject.GetComponents<T>();
            
            if (components.Length == 0)
            {
                throw new ComponentNotFoundException(gameObject, typeof(T));
            }

            foreach (var component in components)
            {
                _action?.Invoke(component);
            }
        }
    }
}