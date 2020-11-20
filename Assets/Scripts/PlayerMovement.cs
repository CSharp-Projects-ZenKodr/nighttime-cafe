using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivity = 20f;
    public float jumpForce = 2f;
    public float maxSpeed = 5f;
    public int maxJumps = 2;
    public Transform groundCheck;
    public new Transform camera;

    public float accelerationModifier = 0.5f;
    private Vector3 _direction;
    private Vector3 _input;
    private int _jumpCount;

    // 0 for standing still, 1 for acceleration, 2 for maximum speed, 3 for deceleration
    private int _movementState;
    private float _pitch;
    private Transform _pos;
    private Vector3 _previousInput;
    private Rigidbody _rb;
    private float _speed;
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
        ChangeMovementState();

        Look();

        if (IsGrounded()) _jumpCount = maxJumps;

        // At the end reset previous input variable
        _previousInput = _input;
    }

    private void FixedUpdate()
    {
        SpeedChange();
        Move();
    }

    // Methods
    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _jumpCount--;
    }

    // Moving the player
    private void Move()
    {
        _direction = _pos.forward * _input.z + _pos.right * _input.x;

        _rb.velocity = _direction * _speed + Vector3.up * _rb.velocity.y;
    }

    // Determining and changing speed
    private void SpeedChange()
    {
        switch (_movementState)
        {
            case 0:
                _speed = 0f;
                break;
            case 1:
                _speed += accelerationModifier;
                break;
            case 2:
                _speed = maxSpeed;
                break;
            case 3:
                _speed -= accelerationModifier;
                break;
        }
    }

    // Camera movement
    private void Look()
    {
        _xRotation -= _pitch * sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        camera.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
        _pos.Rotate(Vector3.up * (_yaw * sensitivity * Time.deltaTime));
    }

    // Ground check
    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, LayerMask.GetMask("Ground"));
    }

    // Determining how to change speed for smooth motion
    private void ChangeMovementState()
    {
        const float tolerance = 0.01f;

        if (_input != Vector3.zero && _previousInput == Vector3.zero) _movementState = 1;
        if (_input == Vector3.zero && _previousInput != Vector3.zero) _movementState = 3;
        if (_movementState == 1 && Math.Abs(_speed - maxSpeed) < tolerance) _movementState = 2;
        if (_movementState == 3 && _speed < tolerance) _movementState = 0;
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