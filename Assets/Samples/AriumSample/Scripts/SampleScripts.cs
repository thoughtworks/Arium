using UnityEngine;
using UnityEngine.UI;

namespace Samples.AriumSample.Scripts
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
