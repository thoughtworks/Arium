using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityPointerClick : Interaction<IPointerClickHandler>
    {
        private PointerEventData _eventData;
        
        public UnityPointerClick()
        {
            SetAction(Click);
        }

        public UnityPointerClick(PointerEventData eventData)
        {
            SetAction(Click);
            _eventData = eventData;
        }

        private void Click(IPointerClickHandler gameObject)
        {
            if (_eventData == null) 
                _eventData = new PointerEventData(EventSystem.current);
            
            gameObject.OnPointerClick(_eventData);
        }
    }
}
