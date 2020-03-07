using System.Collections;
using System.Collections.Generic;
using AriumFramework;
using AriumFramework.Plugins.UnityInteractions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Sample.Tests
{
    public class FrameworkRunner
    {
        private Arium _arium;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _arium = new Arium(new HashSet<IInteraction>
            {
                new UnityButtonClick(),
                new UnityPushObject()
            });

            SceneManager.LoadScene("SampleScene");
        }
        
        [UnityTest]
        public IEnumerator ShouldChangeTextOnButtonClick()
        {
            yield return new WaitForSeconds(2);
            Text display = _arium.GetComponent<Text>("Display");

//            string display = _arium.GetText("Display");

            Assert.AreEqual("New Text", display.text);
            
            _arium.PerformAction(typeof(UnityButtonClick), "Button");
            yield return null;
            
            Assert.AreEqual("Button Clicked!", display.text);
        }
        
        [UnityTest]
        public IEnumerator ShouldPushTheBoxUp()
        {
            const float force = 25;
            
            yield return new WaitForSeconds(2);
            GameObjectWrapper box = _arium.GetObject("Box");
            Transform boxTransform = box.GetComponent<Transform>();

            Assert.AreEqual(Vector3.zero, boxTransform.position);
            UnityPushObject.Force = Vector3.up * force;
            
            _arium.PerformAction(typeof(UnityPushObject), "Box");
            
            yield return new WaitForSeconds(1);
            
            Assert.AreEqual(0, boxTransform.position.x);
            Assert.AreNotEqual(0, boxTransform.position.y);
            Assert.AreEqual(0, boxTransform.position.z);
        }
    }
}