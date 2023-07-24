using System.Collections;
using AriumFramework;
using AriumFramework.Plugins.UnityCore.Extensions;
using AriumFramework.Plugins.UnityCore.Interactions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

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
        

        [UnityTest,Order(1)]
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
        
        [UnityTest,Order(2)]
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
        
        [UnityTest,Order(3)]
        public IEnumerator VerifyCubePositionIsZeroByDefault()
        {
            yield return new WaitForSeconds(2);
            GameObject cube = _arium.FindGameObject("Cube");

            //Validate cube position is zero by default
            Assert.AreEqual(Vector3.zero, cube.GetComponent<Transform>().position);
            yield return null;
            
        }
        
        [UnityTest,Order(4)]
        public IEnumerator VerifyCubePositionIsChangedOnClickingOnChangePosition()
        {
            yield return new WaitForSeconds(2);
            GameObject cube = _arium.FindGameObject("Cube");
            string changePosition = "ChangePosition";

            //Validate cube position is zero by default
            Assert.AreEqual(Vector3.zero, cube.GetComponent<Transform>().position);
            yield return null;
            
            //Click on change position button
            _arium.PerformAction(new UnityPointerClick(), changePosition);
            yield return new WaitForSeconds(1);
            
            //Validate the cube has moved up
            Assert.AreEqual(Vector3.up, cube.GetComponent<Transform>().position);
            yield return null;
            
            //Click on change position button
            _arium.PerformAction(new UnityPointerClick(), changePosition);
            yield return new WaitForSeconds(1);
            
            //Validate the cube has moved right
            Assert.AreEqual(Vector3.right, cube.GetComponent<Transform>().position);
            yield return null;
            
            //Click on change position button
            _arium.PerformAction(new UnityPointerClick(), changePosition);
            yield return new WaitForSeconds(1);
            
            //Validate the cube has moved down
            Assert.AreEqual(Vector3.down, cube.GetComponent<Transform>().position);
            yield return null;
            
            //Click on change position button
            _arium.PerformAction(new UnityPointerClick(), changePosition);
            yield return new WaitForSeconds(1);
            
            //Validate the cube has moved left
            Assert.AreEqual(Vector3.left, cube.GetComponent<Transform>().position);
            yield return null;
            
            //Click on change position button
            _arium.PerformAction(new UnityPointerClick(), changePosition);
            yield return new WaitForSeconds(1);
            
            //Validate the cube has moved zero
            Assert.AreEqual(Vector3.zero, cube.GetComponent<Transform>().position);
            yield return null;
        }
        
        
    }
}