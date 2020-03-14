using System;
using System.Collections;
using System.Collections.Generic;
using AriumFramework;
using AriumFramework.Plugins.UnityCore.Extensions;
using AriumFramework.Plugins.UnityCore.Interactions;
using JetBrains.Rider.Unity.Editor;
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
            _arium = new Arium(new HashSet<IInteraction>
            {
                new UnityButtonClick(),
                new UnityPushObject(),
            });

            SceneManager.LoadScene("UnitySampleScene");
        }
        
        [UnityTest]
        public IEnumerator ShouldChangeTextOnButtonClick()
        {
            yield return new WaitForSeconds(2);
            GameObject display = _arium.FindGameObject("Display");

//            string display = _arium.GetText("Display");

            Assert.AreEqual("New Text", _arium.FindGameObject("Display").GetText());
            
            _arium.PerformAction(typeof(UnityButtonClick), "Button");
            yield return null;
            
            Assert.AreEqual("Button Clicked!", display.GetText());
        }
        
        [UnityTest]
        public IEnumerator ShouldPushTheBoxUp()
        {
            const float force = 25;
            
            yield return new WaitForSeconds(2);
            GameObject box = _arium.FindGameObject("Box");
            Transform boxTransform = box.GetComponent<Transform>();

            Assert.AreEqual(Vector3.zero, boxTransform.position);
            UnityPushObject.Force = Vector3.up * force;
            
            _arium.PerformAction(typeof(UnityPushObject), "Box");
            
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
    }
}