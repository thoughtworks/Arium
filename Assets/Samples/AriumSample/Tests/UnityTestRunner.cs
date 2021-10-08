using System.Collections;
using AriumFramework;
using AriumFramework.Exceptions;
using AriumFramework.Plugins.UnityCore.Extensions;
using AriumFramework.Plugins.UnityCore.Interactions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Samples.AriumSample.Tests
{
    public class UnityTestRunner
    {
        private Arium _arium;

        [OneTimeSetUp]
        public void SetUp()
        {
            _arium = new Arium();

            SceneManager.LoadScene("UnitySampleScene");
        }

        [UnityTest]
        public IEnumerator ShouldChangeTextOnButtonClick()
        {
            yield return new WaitForSeconds(2);
            GameObject display = _arium.FindGameObject("Display");

//            string display = _arium.GetText("Display");

            Assert.AreEqual("New Text", _arium.FindGameObject("Display").GetText());

            _arium.PerformAction(new UnityPointerClick(), "Button");
            yield return null;

            Assert.AreEqual("Button Clicked!", display.GetText());
        }
        
        /// <summary>
        /// This test is almost same as ShouldChangeTextOnButtonClick() but use UnityEventSystemInteraction generic class to simulate Button Click
        /// </summary>
        [UnityTest]
        public IEnumerator ShouldChangeTextOnButtonClickUsingUnityEventSystemInteractionClass()
        {
            yield return new WaitForSeconds(2);
            GameObject display = _arium.FindGameObject("Display");
            string initialText = "New Text";
            display.GetComponent<Text>().text = initialText;
            //Click directly using Unity Event System Interfaces (IPointerClickHandler for button to be clicked) 
            UnityEventSystemInteraction<IPointerClickHandler>.PerformAction("Button");
            yield return null;

            Assert.AreEqual("Button Clicked!", display.GetText());
        }

        [UnityTest]
        public IEnumerator ShouldPushTheBoxUp()
        {
            const float force = 25;
            const string boxObjectName = "Box";
            yield return new WaitForSeconds(2);

            Transform boxTransform = _arium.GetComponent<Transform>(boxObjectName);
            Assert.AreEqual(Vector3.zero, boxTransform.position);
            UnityPushObject.Force = Vector3.up * force;

            _arium.PerformAction(new UnityPushObject(), boxObjectName);

            yield return new WaitForSeconds(1);
            var position = boxTransform.position;
            Assert.AreEqual(0, position.x);
            Assert.AreNotEqual(0, position.y);
            Assert.AreEqual(0, position.z);
        }

        [UnityTest]
        public IEnumerator ShouldChangeAnimations()
        {
            GameObject animatedObject = _arium.FindGameObject("AnimatedObject");

            yield return new WaitForSeconds(2);

            _arium.PerformAction(new UnityAnimationTrigger("ChangeState"), animatedObject);

            yield return new WaitForSeconds(2);

            Assert.IsTrue(animatedObject.IsInAnimationState("State2"));
        }

        [UnityTest]
        public IEnumerator ShouldDrag()
        {
            const string slider = "Slider";
            const float half = 0.5f;

            Transform sliderTransform = _arium.GetComponent<Transform>(slider);
            var rect = _arium.GetComponent<RectTransform>(slider).rect;

            _arium.PerformAction(
                new UnityDrag(new Vector2(sliderTransform.position.x + half * rect.width, sliderTransform.position.y)),
                slider);
            yield return new WaitForSeconds(2);
            Assert.AreEqual(1, _arium.GetComponent<Slider>(slider).value);
        }
        
        /// <summary>
        /// This test is almost same as ShouldDrag() but use UnityEventSystemInteraction generic class to simulate Drag
        /// </summary>
        [UnityTest]
        public IEnumerator ShouldDragUsingUnityEventSystemInteractionClass()
        {
            const string slider = "Slider";
            const float half = 0.5f;

            Transform sliderTransform = _arium.GetComponent<Transform>(slider);
            var sliderComponent = _arium.GetComponent<Slider>(slider);
            sliderComponent.value = half;
            var rect = _arium.GetComponent<RectTransform>(slider).rect;
            //Drag directly using Unity Event System Interfaces (IDragHandler for slider to be dragged) 
            UnityEventSystemInteraction<IDragHandler>.PerformAction(slider, new PointerEventData(EventSystem.current){
                position = new Vector2(sliderTransform.position.x + half * rect.width, sliderTransform.position.y),
            });
            yield return null;
            Assert.AreEqual(1, sliderComponent.value);
        }

        [UnityTest]
        public IEnumerator ShouldDestroyObject()
        {
            var nameOfObjectToDestroy = "ObjectToDestroy";
            var objectToDestroy = _arium.FindGameObject(nameOfObjectToDestroy);
            Object.Destroy(objectToDestroy);
            yield return null;
            Assert.Throws<GameObjectNotFoundException>(() => _arium.FindGameObject(nameOfObjectToDestroy));
        }
    }
}