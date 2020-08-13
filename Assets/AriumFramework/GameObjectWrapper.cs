using System;
using AriumFramework.Exceptions;
using UnityEngine;
using UnityEngine.Events;

namespace AriumFramework
{
    internal class GameObjectWrapper
    {
        private readonly GameObject _currentGameObject;
        private readonly string _originalName;

        internal GameObjectWrapper(string gameObjectName)
        {
            _originalName = gameObjectName;
            if (string.IsNullOrEmpty(_originalName)) 
                throw new ArgumentException("Empty game object name");

            _currentGameObject = GameObject.Find(_originalName);

            if (_currentGameObject == null)
            {
                throw new GameObjectNotFoundException(_originalName);
            }
        }

        internal GameObjectWrapper(GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException();
            
            _currentGameObject = gameObject;
        }

        internal void AddTracker(UnityAction<string> onDestroy)
        {
            AriumObjectTracker tracker = _currentGameObject.AddComponent<AriumObjectTracker>();
            if (tracker == null) 
                tracker = _currentGameObject.GetComponent<AriumObjectTracker>();
            
            tracker.Initialize(() => onDestroy?.Invoke(_originalName));
        }

        public T GetComponent<T>()
        {
            T component = _currentGameObject.GetComponent<T>();
            
            if (component == null)
            {
                throw new ComponentNotFoundException(GetObject(), typeof(T));
            }
            
            return component;
        }

        public override string ToString()
        {
            return _currentGameObject.scene + " --- " + _currentGameObject.name;
        }

        public GameObject GetObject()
        {
            return _currentGameObject;
        }
    }
}