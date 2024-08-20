using UnityEngine;

public class PlayerCameraLook : MonoBehaviour
{

    private const float _SENSETIVITY = 100.0f;

    [SerializeField] private Transform _playerTr;

    private float _yRot = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _SENSETIVITY * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _SENSETIVITY * Time.deltaTime;

        _yRot -= mouseY;
        _yRot = Mathf.Clamp(_yRot, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(_yRot, 0.0f, 0.0f);
        _playerTr.Rotate(Vector3.up * mouseX);
    }
}
