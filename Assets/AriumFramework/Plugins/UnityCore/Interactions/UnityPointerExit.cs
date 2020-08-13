using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityPointerExit : Interaction<IPointerExitHandler>
    {
        private PointerEventData _eventData;
        
        public UnityPointerExit()
        {
            SetAction(FocusOut);
        }

        public UnityPointerExit(PointerEventData eventData)
        {
            SetAction(FocusOut);
            _eventData = eventData;
        }

        private void FocusOut(IPointerExitHandler gameObject)
        {
            if (_eventData == null) 
                _eventData = new PointerEventData(EventSystem.current);
            
            gameObject.OnPointerExit(_eventData);
        }
    }
}
