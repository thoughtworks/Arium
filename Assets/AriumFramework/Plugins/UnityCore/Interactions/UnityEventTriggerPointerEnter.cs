using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityEventTriggerPointerEnter : Interaction<EventTrigger>
    {
        private PointerEventData _eventData;
        
        public UnityEventTriggerPointerEnter() 
        {
            SetAction(FocusIn);
        }
        
        public UnityEventTriggerPointerEnter(PointerEventData eventData)
        {
            SetAction(FocusIn);
            _eventData = eventData;
        }

        private void FocusIn(EventTrigger gameObject)
        {
            if (_eventData == null) 
                _eventData = new PointerEventData(EventSystem.current);
            gameObject.OnPointerEnter(_eventData);
        }
    }
}
