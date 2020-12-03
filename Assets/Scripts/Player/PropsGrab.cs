using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PropsGrab : NetworkBehaviour
    {
        private GameObject _prop;

        private PlayerInput _controls;

        public override void OnStartLocalPlayer()
        {
            _controls = new PlayerInput();
            _controls.Enable();
            _controls.Player.GrabEnter.performed += ctx => OnGrabEnter();
            _controls.Player.GrabExit.performed += ctx => OnGrabExit();
        }

        private void OnGrabEnter()
        {
            if (Camera.main is null) return;
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (!Physics.Raycast(ray, out var hit, 100)) return;
            if (!hit.transform.gameObject.CompareTag("Prop")) return;
            _prop = hit.transform.gameObject;
            Debug.Log(_prop.name + " Hit!");
        }

        private void OnGrabExit()
        {
            _prop = null;
        }
    }
}