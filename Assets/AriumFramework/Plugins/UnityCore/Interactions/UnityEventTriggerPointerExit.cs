using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityEventTriggerPointerExit : Interaction<EventTrigger>
    {
        private PointerEventData _eventData;
        
        public UnityEventTriggerPointerExit() 
        {
            SetAction(FocusIn);
        }
        
        public UnityEventTriggerPointerExit(PointerEventData eventData)
        {
            SetAction(FocusIn);
            _eventData = eventData;
        }

        private void FocusIn(EventTrigger gameObject)
        {
            if (_eventData == null) 
                _eventData = new PointerEventData(EventSystem.current);
            gameObject.OnPointerExit(_eventData);
        }
    }
}
