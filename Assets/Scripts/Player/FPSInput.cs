using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private float _gravity = -9.8f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;       
        float deltaZ = Input.GetAxis("Vertical") * _speed;          

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);        
        movement.y = _gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);          
        _characterController.Move(movement);        
    }
}
