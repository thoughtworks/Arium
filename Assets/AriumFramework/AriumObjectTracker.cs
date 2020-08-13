using UnityEngine;
using UnityEngine.Events;

namespace AriumFramework
{
    public class AriumObjectTracker : MonoBehaviour
    {
        private UnityAction _onObjectDestroy;

        internal void Initialize(UnityAction onObjectDestroy)
        {
            _onObjectDestroy = onObjectDestroy;
        }

        private void OnDestroy()
        {
            _onObjectDestroy?.Invoke();
        }
    }
}