using System;
using System.Collections.Generic;
using AriumFramework.Exceptions;
using UnityEngine;

namespace AriumFramework
{
    public class Arium
    {
        private readonly Dictionary<string, GameObject> _gameObjectCache =
            new Dictionary<string, GameObject>();

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

        public void PerformAction(Type interactionType, string gameObjectName)
        {
            PerformAction(interactionType, FindGameObject(gameObjectName));
        }

        public void PerformAction(Type interactionType, GameObject gameObject)
        {
            if (!_interactions.ContainsKey(interactionType))
                throw new InteractionNotFoundException(interactionType);

            PerformAction(_interactions[interactionType], gameObject);
        }

        public void PerformAction(IInteraction interaction, GameObject gameObject)
        {
            if (interaction == null) 
                throw new ArgumentNullException(); 
            
            interaction.PerformAction(gameObject);
        }

        public T GetComponent<T>(string gameObjectName) where T : Component
        {
            return new GameObjectWrapper(FindGameObject(gameObjectName)).GetComponent<T>();
        }

        public GameObject FindGameObject(string gameObjectName)
        {
            try
            {
                if (!_gameObjectCache.ContainsKey(gameObjectName))
                {
                    _gameObjectCache.Add(gameObjectName, new GameObjectWrapper(gameObjectName).GetObject());
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