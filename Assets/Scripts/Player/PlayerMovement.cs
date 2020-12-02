using System;
using Mirror;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : NetworkBehaviour
    {
        public float maxSpeed = 5f;
        public float accelerationModifier = 1f;
        private float _speed;
        public float jumpForce = 3f;

        public Transform groundCheck;
        private Transform _pos;
        private Rigidbody _rb;

        private PlayerInput _controls;

        private Vector3 _input;
        private Vector3 _lastNotNullInput;
        private Vector3 _previousInput;
        private Vector3 _velocity;

        private enum MovementStates
        {
            Acceleration,
            MaxSpeed,
            Deceleration,
            Stop
        }

        private MovementStates _state;

        private void Update()
        {
            if (!isLocalPlayer) return;
            
            if (_input != Vector3.zero) _lastNotNullInput = _input;
            
            SwitchStates();
        }

        private void FixedUpdate()
        {
            SwitchSpeed();
                        
            if (_rb.velocity != _velocity && IsGrounded())
                Move(_velocity);
        }

        private void LateUpdate()
        {
            _previousInput = _input;
        }

        private void OnMove(Vector2 value)
        {
            if (!isLocalPlayer) return;

            _input = new Vector3(value.x, 0f, value.y);
        }

        private void SwitchStates()
        {
            const float tolerance = 0.1f;

            if (_previousInput == Vector3.zero && _input != Vector3.zero)
                _state = MovementStates.Acceleration;
            else if (_previousInput != Vector3.zero && _input == Vector3.zero)
                _state = MovementStates.Deceleration;
            else if (_state == MovementStates.Acceleration && Mathf.Abs(_speed - maxSpeed) <= tolerance)
                _state = MovementStates.MaxSpeed;
            else if (_state == MovementStates.Deceleration && _speed < tolerance)
                _state = MovementStates.Stop;
        }

        private void SwitchSpeed()
        {
            switch (_state)
            {
                case MovementStates.Acceleration:
                    _speed += accelerationModifier;
                    break;
                case MovementStates.MaxSpeed:
                    _speed = maxSpeed;
                    break;
                case MovementStates.Deceleration:
                    _speed -= accelerationModifier;
                    break;
                case MovementStates.Stop:
                    _speed = 0f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var forward = _pos.forward;
            var right = _pos.right;
            var direction = _state == MovementStates.Deceleration
                ? forward * _lastNotNullInput.z + right * _lastNotNullInput.x
                : forward * _input.z + right * _input.x;
            _velocity = direction * _speed + Vector3.up * _rb.velocity.y;
        }

        private void OnJump()
        {
            if (!isLocalPlayer || !IsGrounded()) return;

            Jump();
        }

        public override void OnStartLocalPlayer()
        {
            _rb = GetComponent<Rigidbody>();
            _pos = GetComponent<Transform>();

            _rb.isKinematic = false;

            _controls = new PlayerInput();
            _controls.Enable();
            _controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
            _controls.Player.Jump.performed += ctx => OnJump();
        }

        private bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheck.position, 0.15f, LayerMask.GetMask("Ground"));
        }

        [Client]
        private void Move(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }

        [Client]
        private void Jump()
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}