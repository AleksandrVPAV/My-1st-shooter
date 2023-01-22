using System.Collections;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes       
    {
        MouseXAndY = 0,
        MouseY = 1,
        MouseX = 2
    }

    [SerializeField] private RotationAxes axes = RotationAxes.MouseXAndY;
    [SerializeField] private float _sensitivityHor;
    [SerializeField] private float _sensitivityVert;

    private float _minimumVert = -45.0f;
    private float _maximumVert = 45.0f;

    private float _rotationX = 0;               

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;           
        }
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;              
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);       

            float delta = Input.GetAxis("Mouse X") * _sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else if (axes == RotationAxes.MouseX)                                      
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);     
                                                                                  
        }
        else if (axes == RotationAxes.MouseY)                                       
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;              
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);      

            float rotationY = transform.localEulerAngles.y;                       

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);     
        }
    }

}
