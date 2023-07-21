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
    public class SampleSceneTests
    {
        private Arium _arium;

        [OneTimeSetUp]
        public void SetUp()
        {
            _arium = new Arium();

            SceneManager.LoadScene("SampleScene");
        }
        

        [UnityTest]
        public IEnumerator OnClickingChangeColorCubeColorShouldBeChanged()
        {
            yield return new WaitForSeconds(2);
            GameObject cube = _arium.FindGameObject("Cube");
            string changeColorButton = "ChangeColor";
            
            //Validate default color of the cube is white
            Assert.AreEqual(Color.white, cube.GetComponent<MeshRenderer>().material.color);

            _arium.PerformAction(new UnityPointerClick(), changeColorButton);
            yield return new WaitForSeconds(1);
            
            //Validate cube color has changed to Green
            Assert.AreEqual(Color.green, cube.GetComponent<MeshRenderer>().material.color);
            
            _arium.PerformAction(new UnityPointerClick(), changeColorButton);
            yield return new WaitForSeconds(1);
            
            //Validate cube color has changed to Green
            Assert.AreEqual(Color.red, cube.GetComponent<MeshRenderer>().material.color);
        }
        
        [UnityTest]
        public IEnumerator OnResetCubeColorShouldBeChangedAndResetButtonShouldNotBeInteractable()
        {
            yield return new WaitForSeconds(2);
            GameObject cube = _arium.FindGameObject("Cube");
            string resetButton = "Reset";
            
            //Validate color of the cube is not white
            Assert.AreNotEqual(Color.white, cube.GetComponent<MeshRenderer>().material.color);
            
            //Click reset button
            _arium.PerformAction(new UnityPointerClick(), resetButton);
            yield return new WaitForSeconds(1);
            
            //Validate cube color has been reset to white
            Assert.AreEqual(Color.white, cube.GetComponent<MeshRenderer>().material.color);
            yield return new WaitForSeconds(1);
            
            //Validate reset button is not interactable
            Assert.False(TextUtils.IsGameObjectInteractable(_arium.FindGameObject(resetButton)));
        }
    }
}