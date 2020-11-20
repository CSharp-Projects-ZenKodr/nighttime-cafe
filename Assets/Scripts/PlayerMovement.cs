using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivity = 20f;
    public float jumpForce = 2f;
    public float speed = 5f;
    public int maxJumps = 2;
    public Transform groundCheck;
    public new Transform camera;
    private Vector3 _direction;
    private Vector3 _input;
    private int _jumpCount;
    private float _pitch;
    private Transform _pos;
    private Rigidbody _rb;
    private float _xRotation;
    private float _yaw;

    // Unity event functions
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pos = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
        Move();

        if (IsGrounded()) _jumpCount = maxJumps;
    }

    // Methods
    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _jumpCount--;
    }

    private void Move()
    {
        _direction = _pos.forward * _input.z + _pos.right * _input.x;

        _rb.velocity = _direction * speed + Vector3.up * _rb.velocity.y;
    }

    private void Look()
    {
        _xRotation -= _pitch * sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        camera.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
        _pos.Rotate(Vector3.up * (_yaw * sensitivity * Time.deltaTime));
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, LayerMask.GetMask("Ground"));
    }

    // Input event functions
    [UsedImplicitly]
    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _input = new Vector3(value.x, 0f, value.y);
    }

    [UsedImplicitly]
    public void OnJump(InputAction.CallbackContext context)
    {
        if (_jumpCount > 0) Jump();
    }

    [UsedImplicitly]
    public void OnLook(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _yaw = value.x;
        _pitch = value.y;
    }
}