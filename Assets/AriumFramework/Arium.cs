using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AriumFramework
{
    public class Arium
    {
        private readonly Dictionary<string, GameObjectWrapper> _gameObjectCache = new Dictionary<string, GameObjectWrapper>();
        private readonly Dictionary<Type, IInteraction> _interactions;

        public Arium(HashSet<IInteraction> interactions)
        {
            _interactions = new Dictionary<Type, IInteraction>();

            foreach (IInteraction interaction in interactions)
            {
                _interactions.Add(interaction.GetType(), interaction);
            }
        }

        public void PerformAction(Type interactionType, string gameObjectName)
        {
            _interactions[interactionType].PerformAction(GetObject(gameObjectName));
        }

        public T GetComponent<T>(string gameObjectName) where T : Component
        {
            return GetObject(gameObjectName).GetComponent<T>();
        }

        public string GetText(string gameObjectName)
        {
            return GetComponent<Text>(gameObjectName).text;
        }

        public GameObjectWrapper GetObject(string gameObjectName)
        {
            try
            {
                if (!_gameObjectCache.ContainsKey(gameObjectName))
                {
                    _gameObjectCache.Add(gameObjectName, new GameObjectWrapper(gameObjectName));
                }

                return _gameObjectCache[gameObjectName];
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Could not Find GameObject");
                throw;
            }
        }
    }
}