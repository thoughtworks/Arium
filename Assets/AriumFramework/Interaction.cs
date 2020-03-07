using UnityEngine;
using UnityEngine.Events;

namespace AriumFramework
{
    public abstract class Interaction<T> : IInteraction where T : Component
    {
        private readonly UnityAction<T> _action;

        protected Interaction(UnityAction<T> action)
        {
            _action = action;
        }

        public void PerformAction(GameObjectWrapper objectToBeClicked)
        {
            _action.Invoke(objectToBeClicked.GetComponent<T>());
        }
    }
}