using Mirror;
using UnityEngine;

namespace Player
{
    public class CameraMovement : NetworkBehaviour
    {
        public new Transform camera;
        public float sensitivity = 20f;
        private PlayerInput _controls;
        private Vector2 _input;
        private Transform _pos;
        private Vector2 _previousInput;
        private float _xRotation;
        private float _yaw;
        private float Pitch => _input.y * sensitivity * Time.deltaTime;
        private float Yaw => _input.x * sensitivity * Time.deltaTime;

        private void Update()
        {
            if (!isLocalPlayer) return;

            if (_input != _previousInput)
                CmdLook();

            _previousInput = _input;
        }

        public override void OnStartLocalPlayer()
        {
            _pos = GetComponent<Transform>();
            Cursor.lockState = CursorLockMode.Locked;

            _controls = new PlayerInput();
            _controls.Enable();
            _controls.Player.Look.performed += ctx => OnLook(ctx.ReadValue<Vector2>());
        }

        private void OnLook(Vector2 value)
        {
            if (!isLocalPlayer) return;

            _input = value;
        }

        [Command]
        private void CmdLook()
        {
            _xRotation -= Pitch;

            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            camera.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
            _pos.Rotate(Vector3.up * Yaw);
        }
    }
}