using JetBrains.Annotations;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    public float defaultJumpForce = 2f;
    public float maxSpeed = 5f;
    public int maxJumps = 2;
    public Transform groundCheck;

    public float accelerationModifier = 0.5f;
    public float secondJumpModifier = 2f;

    public float sprintModifier = 3f;
    private Vector3 _direction;
    private Vector3 _input;
    private int _jumpCount;
    private float _jumpForce;
    private Vector3 _lastNonNullInput;

    // 0 for standing still, 1 for acceleration, 2 for maximum speed, 3 for deceleration
    private int _movementState;
    private Transform _pos;
    private Vector3 _previousInput;
    private Rigidbody _rb;
    private float _speed;
    private float _xRotation;

    public override void OnStartLocalPlayer()
    {
        _rb = GetComponent<Rigidbody>();
        _pos = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!hasAuthority) return;
        
        ChangeMovementState();

        if (IsGrounded()) _jumpCount = maxJumps;

        _jumpForce = defaultJumpForce;
        if (_jumpCount < maxJumps)
            _jumpForce += secondJumpModifier;

        // At the end reset previous input variable
        _previousInput = _input;
    }

    private void FixedUpdate()
    {
        if (!hasAuthority) return;
        
        SpeedChange();
        Move();
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _jumpCount--;
    }

    // Moving the player
    private void Move()
    {
        if (IsGrounded())
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

        var forward = _pos.forward;
        var right = _pos.right;
        _direction = _movementState == 3
            ? forward * _lastNonNullInput.z + right * _lastNonNullInput.x
            : forward * _input.z + right * _input.x;
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
        if (_movementState == 1 && Mathf.Abs(_speed - maxSpeed) < tolerance) _movementState = 2;
        if (_movementState == 3 && _speed < tolerance) _movementState = 0;
    }

    [UsedImplicitly]
    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _input = new Vector3(value.x, 0f, value.y);

        if (_input != Vector3.zero) _lastNonNullInput = _input;
    }

    [UsedImplicitly]
    public void OnJump(InputAction.CallbackContext context)
    {
        if (_jumpCount > 0) Jump();
    }

    [UsedImplicitly]
    public void OnSprintOn(InputAction.CallbackContext context)
    {
        maxSpeed += sprintModifier;
    }

    [UsedImplicitly]
    public void OnSprintOff(InputAction.CallbackContext context)
    {
        maxSpeed -= sprintModifier;
    }
}