using UnityEngine.EventSystems;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityPointerExit : Interaction<IPointerExitHandler>
    {
        public UnityPointerExit() : base(FocusOut)
        {
        }

        private static void FocusOut(IPointerExitHandler gameObject)
        {
            gameObject.OnPointerExit(new PointerEventData(EventSystem.current));
        }
    }
}
