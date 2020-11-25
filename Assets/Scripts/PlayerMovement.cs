using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    public Transform groundCheck;
    public float jumpForce = 3f;
    private PlayerInput _controls;
    private Vector3 _input;
    private Vector3 _previousInput;
    private Vector3 _velocity;

    private Rigidbody _rb;

    private void Update()
    {
        if (!isLocalPlayer) return;

        _velocity = _input * speed + Vector3.up * _rb.velocity.y;

        if (_rb.velocity != _velocity)
            CmdMove(_velocity);

        _previousInput = _input;
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void OnMove(Vector2 value)
    {
        if (!isLocalPlayer) return;
        
        var input = new Vector3(value.x, 0f, value.y);

        if (input != _previousInput)
            CmdMovementInput(input);
    }

    private void OnJump()
    {
        if (!isLocalPlayer || !IsGrounded()) return;
        
        CmdJump();
    }

    public override void OnStartLocalPlayer()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        _controls = new PlayerInput();
        _controls.Enable();
        _controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
        _controls.Player.Jump.performed += ctx => OnJump();
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.15f, LayerMask.GetMask("Ground"));
    }

    [Command]
    private void CmdMove(Vector3 velocity)
    {
        _rb.velocity = velocity;
    }

    [Command]
    private void CmdJump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    [Command]
    private void CmdMovementInput(Vector3 input)
    {
        _input = input;
    }
}