using UnityEngine;
using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityDrag : Interaction<IDragHandler>
    {
        private readonly Vector2 _position;
        
        public UnityDrag(Vector2 position)
        {
            _position = position;
            SetAction(Drag);
        }

        private void Drag(IDragHandler gameObject)
        {
            gameObject.OnDrag(new PointerEventData(EventSystem.current)
            {
                position = _position
            });
        }
    }
}