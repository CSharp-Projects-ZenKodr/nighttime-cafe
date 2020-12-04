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
            _controls.Player.GrabEnter.performed += ctx => OnGrabEnter();
            _controls.Player.GrabExit.performed += ctx => OnGrabExit();
        }

        private void Update()
        {
            if (_prop is null) return;
            
            MoveProp();
        }

        private void MoveProp()
        {
            var vector = grabPos.position - _prop.transform.position;
            _propRb.AddForce(vector, ForceMode.Acceleration);
            _propRb.velocity = Vector3.ClampMagnitude(_propRb.velocity, maxVel);

            _prop.transform.rotation = grabPos.rotation;
        }

        private void OnGrabEnter()
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

        private void OnGrabExit()
        {
            if (_prop is null) return;
            
            _prop.GetComponent<Rigidbody>().useGravity = true;
            _prop = null;
            _propRb = null;
        }
    }
}