using UnityEngine.UI;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityButtonClick : Interaction<Button>
    {
        public UnityButtonClick() : base(Click)
        {
        }

        private static void Click(Button button)
        {
            button.onClick.Invoke();
        }
    }
}
