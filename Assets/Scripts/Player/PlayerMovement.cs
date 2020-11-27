using Mirror;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : NetworkBehaviour
    {
        public float speed = 5f;
        public Transform groundCheck;
        public float jumpForce = 3f;
        private PlayerInput _controls;
        private Vector3 _input;
        private Transform _pos;
        private Vector3 _previousInput;
        private Rigidbody _rb;
        private Vector3 _velocity;

        private void Update()
        {
            if (!isLocalPlayer) return;

            var direction = _pos.forward * _input.z + _pos.right * _input.x;
            _velocity = direction * speed + Vector3.up * _rb.velocity.y;

            if (_rb.velocity != _velocity)
                CmdMove(_velocity);

            _previousInput = _input;
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
            _pos = GetComponent<Transform>();

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
}