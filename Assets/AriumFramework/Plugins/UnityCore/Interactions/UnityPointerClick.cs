using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityPointerClick : Interaction<IPointerClickHandler>
    {
        public UnityPointerClick() : base(Click)
        {
        }

        private static void Click(IPointerClickHandler gameObject)
        {
            gameObject.OnPointerClick(new PointerEventData(EventSystem.current));
        }
    }
}
