using UnityEngine;
using UnityEngine.Events;

namespace AriumFramework
{
    public abstract class Interaction<T> : IInteraction where T : Component
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

        public void PerformAction(GameObjectWrapper gameObject)
        {
            _action.Invoke(gameObject.GetComponent<T>());
        }
    }
}