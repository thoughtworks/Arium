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
            T component = gameObject.GetComponent<T>();
            
            if (component == null)
            {
                throw new ComponentNotFoundException(gameObject, typeof(T));
            }
            
            _action.Invoke(component);
        }
    }
}