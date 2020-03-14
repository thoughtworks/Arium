using System;
using AriumFramework.Exceptions;
using UnityEngine;

namespace AriumFramework
{
    public class GameObjectWrapper
    {
        private readonly GameObject _currentGameObject;

        internal GameObjectWrapper(string gameObjectName)
        {
            if (string.IsNullOrEmpty(gameObjectName)) throw new ArgumentException("Empty game object name");

            _currentGameObject = GameObject.Find(gameObjectName);

            if (_currentGameObject == null)
            {
                throw new GameObjectNotFoundException(gameObjectName);
            }
        }

        internal GameObjectWrapper(GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException();
            
            _currentGameObject = gameObject;
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