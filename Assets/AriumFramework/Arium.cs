using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AriumFramework
{
    public class Arium
    {
        private readonly Dictionary<string, GameObjectWrapper> _gameObjectCache =
            new Dictionary<string, GameObjectWrapper>();

        private readonly Dictionary<Type, IInteraction> _interactions;

        public Arium(HashSet<IInteraction> interactions)
        {
            _interactions = new Dictionary<Type, IInteraction>();

            foreach (IInteraction interaction in interactions)
            {
                _interactions.Add(interaction.GetType(), interaction);
            }
        }

        public void PerformAction(IInteraction interaction, string gameObjectName)
        {
            PerformAction(interaction, FindGameObject(gameObjectName));
        }
        
        public void PerformAction(IInteraction interaction, GameObject gameObject)
        {
            PerformAction(interaction, new GameObjectWrapper(gameObject));
        }
        
        public void PerformAction(Type interactionType, GameObject gameObject)
        {
            GameObjectWrapper objectWrapper = new GameObjectWrapper(gameObject);
            PerformAction(interactionType, objectWrapper);
        }
        
        public void PerformAction(Type interactionType, string gameObjectName)
        {
            PerformAction(interactionType, FindGameObject(gameObjectName));
        }
        
        public void PerformAction(Type interactionType, GameObjectWrapper gameObjectWrapper)
        {
            if (!_interactions.ContainsKey(interactionType)) throw new ArgumentException(); // TODO: Add custom exception
            
            PerformAction(_interactions[interactionType], gameObjectWrapper);
        }
        
        public void PerformAction(IInteraction interaction, GameObjectWrapper objectWrapper)
        {
            interaction.PerformAction(objectWrapper);
        }

        public T GetComponent<T>(string gameObjectName) where T : Component
        {
            return FindGameObject(gameObjectName).GetComponent<T>();
        }

        public GameObjectWrapper FindGameObject(string gameObjectName)
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
