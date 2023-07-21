using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class ChangeScript : MonoBehaviour
{
    private MeshRenderer _renderer;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button scaleUpButton;
    [SerializeField] private Button scaleDownButton;
    [SerializeField] private Button depthIncreaseButton;
    [SerializeField] private Button depthDecreaseButton;
    [SerializeField] private Button rotateLeftButton;
    [SerializeField] private Button rotateRightButton;
    [SerializeField] private GameObject toolTipText;

    private Vector3 _defaultscale = new Vector3(3, 3, 3);
    private Vector3 _maxscale = new Vector3(6, 6, 6);
    private Vector3 _minscale = new Vector3(1, 1, 1);
    private float _maxdepth = 3f;
    private float _mindepth = -3f;
    private float _defaultDepth = 0f;
    private int _maxRotateLeft = -45;
    private int _maxRotateRight = 15;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = Color.white;
        toolTipText.SetActive(false);
    }

    public void ChangeCubeColor()
    {
        if (_renderer.material.color == Color.green)
        {
            _renderer.material.color = Color.red;
        }
        else
        {
            _renderer.material.color = Color.green;
        }
    }

    public void ChangeCubePosition()
    {
        if (transform.position == Vector3.zero)
            transform.position = Vector3.up;
        else if (transform.position == Vector3.up)
            transform.position = Vector3.right;
        else if (transform.position == Vector3.right)
            transform.position = Vector3.down;
        else if (transform.position == Vector3.down)
            transform.position = Vector3.left;
        else if (transform.position == Vector3.left)
            transform.position = Vector3.zero;
    }

    public void ScaleUpCubeSize()
    {
        if (transform.localScale != _maxscale)
            transform.localScale += Vector3.one;
    }

    public void ScaleDownCubeSize()
    {
        if (transform.localScale != _minscale)
            transform.localScale -= Vector3.one;
    }

    public void IncreaseCubeDepth()
    {
        Vector3 currentPosition = transform.position;
        if (Math.Abs(transform.position.z - _maxdepth) > 0.1f)
        {
            currentPosition.z += 1f;
            transform.position = currentPosition;
        }
    }

    public void DecreaseCubeDepth()
    {
        Vector3 currentPosition = transform.position;
        if (Math.Abs(transform.position.z - _mindepth) > 0.1f)
        {
            currentPosition.z -= 1f;
            transform.position = currentPosition;
        }
    }

    public void RotateCubeLeft()
    {
        Vector3 currentPosition = transform.eulerAngles;
        currentPosition.y = _maxRotateLeft;
        transform.eulerAngles = currentPosition;
    }

    public void RotateCubeRight()
    {
        Vector3 currentPosition = transform.eulerAngles;
        currentPosition.y = _maxRotateRight;
        transform.eulerAngles = currentPosition;
    }

    public void MaximizeCubeSize()
    {
        if (transform.localScale != _maxscale)
            transform.localScale = _maxscale;
    }

    public void MinimizeCubeSize()
    {
        if (transform.localScale != _minscale)
            transform.localScale = _minscale;
    }

    public void ShowToolTip(string buttonName)
    {
        toolTipText.SetActive(true);
        switch (buttonName)
        {
            case "ChangeColor":
                toolTipText.transform.GetComponent<TMP_Text>().text = "Click to Modify the colour of the cube";
                break;
        }   
    }
    
    public void HideToolTip()
    {
        toolTipText.SetActive(false);
    }

    public void ResetCube()
    {
        transform.position = Vector3.zero;
        _renderer.material.color = Color.white;
        transform.localScale = _defaultscale;
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        if (transform.position != Vector3.zero || transform.localScale != _defaultscale ||
            _renderer.material.color != Color.white || transform.position.z != 0 ||
            transform.rotation != Quaternion.identity)
        {
            resetButton.interactable = true;
        }
        else
        {
            resetButton.interactable = false;
        }

        if (transform.localScale == _maxscale)
        {
            scaleUpButton.interactable = false;
        }
        else
        {
            scaleUpButton.interactable = true;
        }

        if (transform.localScale == _minscale)
        {
            scaleDownButton.interactable = false;
        }
        else
        {
            scaleDownButton.interactable = true;
        }

        if (Math.Abs(transform.position.z - _maxdepth) < 0.1f)
        {
            depthIncreaseButton.interactable = false;
        }
        else
        {
            depthIncreaseButton.interactable = true;
        }

        if (Math.Abs(transform.position.z - _mindepth) < 0.1f)
        {
            depthDecreaseButton.interactable = false;
        }
        else
        {
            depthDecreaseButton.interactable = true;
        }

        if (Math.Abs(transform.rotation.y - _maxRotateLeft) < 0.1f)
        {
            rotateLeftButton.interactable = false;
        }
        else
        {
            rotateLeftButton.interactable = true;
        }

        if (Math.Abs(transform.rotation.y - _maxRotateRight) < 0.1f)
        {
            rotateRightButton.interactable = false;
        }
        else
        {
            rotateRightButton.interactable = true;
        }
    }
}