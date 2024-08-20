using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float _MOVEMENT_SPEED = 10.0f;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * movY + transform.right * movX;
        _characterController.Move(direction * _MOVEMENT_SPEED * Time.deltaTime);
    }
}
