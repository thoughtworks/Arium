using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityPointerEnter : Interaction<IPointerEnterHandler>
    {
        public UnityPointerEnter() : base(FocusIn)
        {
        }

        private static void FocusIn(IPointerEnterHandler gameObject)
        {
            gameObject.OnPointerEnter(new PointerEventData(EventSystem.current));
        }
    }
}
