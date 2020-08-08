using System.Collections;
using System.Collections.Generic;
using AriumFramework;
using AriumFramework.Plugins.UnityCore.Extensions;
using AriumFramework.Plugins.UnityCore.Interactions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Sample.Tests
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
        
        [UnityTest]
        public IEnumerator ShouldPushTheBoxUp()
        {
            const float force = 25;
            const string BoxObjectName = "Box";
            yield return new WaitForSeconds(2);
            
            Transform boxTransform = _arium.GetComponent<Transform>(BoxObjectName);
            Assert.AreEqual(Vector3.zero, boxTransform.position);
            UnityPushObject.Force = Vector3.up * force;
            
            _arium.PerformAction(new UnityPushObject(), BoxObjectName);
            
            yield return new WaitForSeconds(1);
            Assert.AreEqual(0, boxTransform.position.x);
            Assert.AreNotEqual(0, boxTransform.position.y);
            Assert.AreEqual(0, boxTransform.position.z);
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
        public IEnumerator shouldDrag()
        {
            const string Slider = "Slider";
            const float Half = 0.5f;
            
            Transform SliderTransform = _arium.GetComponent<Transform>(Slider);
            var rect = _arium.GetComponent<RectTransform>(Slider).rect;
            
            _arium.PerformAction(new UnityDrag(new Vector2(SliderTransform.position.x + Half * rect.width, SliderTransform.position.y)), Slider);
            yield return new WaitForSeconds(2);  
            Assert.AreEqual(1,_arium.GetComponent<Slider>(Slider));

        }
    }
}