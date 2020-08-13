using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityPointerEnter : Interaction<IPointerEnterHandler>
    {
        private PointerEventData _eventData;
        
        public UnityPointerEnter() 
        {
            SetAction(FocusIn);
        }
        
        public UnityPointerEnter(PointerEventData eventData)
        {
            SetAction(FocusIn);
            _eventData = eventData;
        }

        private void FocusIn(IPointerEnterHandler gameObject)
        {
            if (_eventData == null) 
                _eventData = new PointerEventData(EventSystem.current);
            
            gameObject.OnPointerEnter(_eventData);
        }
    }
}
