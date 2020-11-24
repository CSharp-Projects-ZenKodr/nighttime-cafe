using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private PlayerInput _controls;
    private Vector3 _input;
    private Vector3 _previousInput;
    public float speed = 5f;

    private Rigidbody _rb;
    
    private void OnMove(Vector2 value)
    {
        var input = new Vector3(value.x, 0f, value.y);
        
        if (input != _previousInput)
            CmdMovementInput(input);

        _previousInput = _input;
    }

    public override void OnStartLocalPlayer()
    {
        _rb = GetComponent<Rigidbody>();
        
        _controls = new PlayerInput();
        _controls.Enable();
        _controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    [Server]
    private void Move()
    {
        _rb.velocity = _input * speed + Vector3.up * _rb.velocity.y;
    }

    [Command]
    private void CmdMovementInput(Vector3 input)
    {
        _input = input;
    }
}
