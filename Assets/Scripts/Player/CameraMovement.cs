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
        private float _xRotation;
        private float Pitch => _input.y * sensitivity * Time.deltaTime;
        private float Yaw => _input.x * sensitivity * Time.deltaTime;

        private void Update()
        {
            if (!isLocalPlayer) return;
            Look(Pitch, Yaw);
        }

        public override void OnStartLocalPlayer()
        {
            _pos = GetComponent<Transform>();
            Cursor.lockState = CursorLockMode.Locked;

            _controls = new PlayerInput();
            _controls.Enable();
            _controls.Player.Look.performed += ctx => OnLook(ctx.ReadValue<Vector2>());

            if (Camera.main is null) return;
            var cameraPos = Camera.main.transform;
            cameraPos.SetParent(camera);
            cameraPos.localPosition = Vector3.zero;
        }

        private void OnLook(Vector2 value)
        {
            if (!isLocalPlayer) return;

            _input = value;
        }

        [Client]
        private void Look(float pitch, float yaw)
        {
            _xRotation -= pitch;

            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            camera.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
            _pos.Rotate(Vector3.up * yaw);
        }
    }
}