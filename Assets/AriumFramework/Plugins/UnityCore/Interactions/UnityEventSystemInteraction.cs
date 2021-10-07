using AriumFramework.Exceptions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public static class UnityEventSystemInteraction<T> where T : IEventSystemHandler
    {
        public static void PerformAction(GameObject gameObject, AbstractEventData eventData = null)
        {
            if (gameObject == null)
            {
                throw new NullGameObjectException();
            }

            eventData ??= new PointerEventData(EventSystem.current);

            var components = gameObject.GetComponents<T>();

            if (components.Length == 0)
            {
                throw new ComponentNotFoundException(gameObject, typeof(T));
            }

            var methodInfos = typeof(T).GetMethods();
            foreach (var component in components)
            {
                foreach (var method in methodInfos)
                {
                    method.Invoke(component, new object[] {eventData});
                }
            }
        }

        public static void PerformAction(string gameObjectName,
            AbstractEventData eventData = null)
        {
            var gameObject = GameObject.Find(gameObjectName);
            if (gameObject == null)
            {
                throw new GameObjectNotFoundException(gameObjectName);
            }

            PerformAction(gameObject, eventData);
        }
    }
}