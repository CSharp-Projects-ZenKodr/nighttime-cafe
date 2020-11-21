using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 20f;
    public Transform player;
    private float _pitch;
    private Transform _pos;
    private float _xRotation;
    private float _yaw;

    // Unity event functions
    private void Start()
    {
        _pos = GetComponent<Transform>();
    }

    private void Update()
    {
        _xRotation -= _pitch * sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _pos.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
        player.Rotate(Vector3.up * (_yaw * sensitivity * Time.deltaTime));
    }

    // Input event functions
    [UsedImplicitly]
    public void OnLook(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _yaw = value.x;
        _pitch = value.y;
    }
}