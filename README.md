# Arium
Automation Testing Framework for AR(Unity) Applications.

##About Arium:
Arium is an automation testing framework for 3D applications built on top of Unity. It helps the Developers/QA to run functional tests on 3D apps on any platforms.
ie., Unity Editor,Android,UWP etc..

Arium comes with the basic Unity interactions:
    Animator
    DragHandler
    PointerClickHandler
    PointerEnterHandler
    PointerExitHandler
    RigidBody

##Setup:
1. Download Arium Unity Package https://github.com/Jayachandranaug29/arium/releases/download/untagged-0a6b6dac1fafc0295a87/AriumWithSample.unitypackage
2. Open your Unity project which needs to be automated.
3. Double click on the downloaded Unity package.
4. Select all and click on Import Button.

##Running Sample Test cases:
1. Open UnitySampleScene in the project hierarchy- Sample >> Scenes >> UnitySampleScene.
2. Open Unity Build settings - File >> Build Settings
3. Click on Add Open Scenes.
    Note: Make sure the UnitySampleScene is selected 
4. Close Unity build settings window
5. Open TestRunner window in Unity - Window >> General >> TestRunner.
6. Expand the Arium hierarchy in the Test Runner - Arium >> Tests.dll >> Sample >> Tests >> UnityTestRunner
7. Select PlayMode Tests and Right click on UnityTestRunner and Click on RUN.
8. Test Cases will start executing and results will be displayed on the TestRunner.

##Arium Usage:

###Instantiate Arium:

To use Arium framework, Arium should be instantiated inside the test class as mentioned below

####syntax:

    <code>
        Arium _arium = new Arium();
    </code>

###Find GameObjects:

To find a Gameobject from the Unity Scene hierarchy using its name.

####syntax:

    <code>
        _arium.FindGameObject("Display");
    </code>
    
#####Paremeters:
    String - Name of the Gameobject.
    
#####Return type:
    UnityEngine.GameObject

###GetComponents:

To retrieve the components attached to a GameObject

####syntax:

    <code>
        _arium.GetComponent<Name of the component here>(Name of the GameObject here)
    </code>
    
#####Paremeters:
    String - Name of the Gameobject.
    UnityComponent - UnityComponent type
    
#####Return type:
    UnityEngine.Component

###PerformActions:

To interact with the UnityGameobjects on runtime.

####syntax:
 To click on a particular gameobject.
 
    <code>
        _arium.PerformAction(new UnityPointerClick(), "Name of the gameobject here");
    </code>
    
#####Paremeters:
    Intercation - Type of the interaction need to performed on a gameobject, in this case it is UnityPointerClick()
    String - Name of the Gameobject.

#Class Diagram
![](ClassDiagram.jpg)