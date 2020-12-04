using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PropsGrab : NetworkBehaviour
    {
        private GameObject _prop;
        private Rigidbody _propRb;
        public Transform grabPos;
        public float maxVel = 0.5f;

        private PlayerInput _controls;

        public override void OnStartLocalPlayer()
        {
            _controls = new PlayerInput();
            _controls.Enable();
            _controls.Player.Grab.performed += ctx => OnGrab();
        }

        private void FixedUpdate()
        {
            if (_prop is null) return;
            
            MoveProp();
        }

        private void MoveProp()
        {
            var vector = grabPos.position - _prop.transform.position;
            var velocity = vector.magnitude * vector.magnitude * maxVel;
            
            _propRb.AddForce(vector);
            _propRb.velocity = Vector3.ClampMagnitude(_propRb.velocity, velocity);
            _propRb.velocity = Vector3.ClampMagnitude(_propRb.velocity, 2 * maxVel);
            _prop.transform.rotation = grabPos.rotation;
        }

        private void OnGrab()
        {
            if (_prop is null)
                GrabProp();
            else
                ReleaseProp();
        }

        private void ReleaseProp()
        {
            _propRb.useGravity = true;
            _prop = null;
            _propRb = null;
        }

        private void GrabProp()
        {
            if (Camera.main is null) return;
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (!Physics.Raycast(ray, out var hit, 2f)) return;
            if (!hit.transform.gameObject.CompareTag("Prop")) return;

            _prop = hit.transform.gameObject;
            _propRb = _prop.GetComponent<Rigidbody>();
            _propRb.useGravity = false;

            Debug.Log(_prop.name + " hit!");
        }
    }
}