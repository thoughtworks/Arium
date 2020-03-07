using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts
{
    public class SampleScripts : MonoBehaviour
    {
        [SerializeField] private Text display;

        public void OnButtonClick()
        {
            display.text = "Button Clicked!";
        }
    }
}
