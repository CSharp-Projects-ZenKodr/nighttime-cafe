using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class ItemsGrab : NetworkBehaviour
    {
        private GameObject _item;
        private Rigidbody _itemRb;
        
        public Transform grabPos;
        private bool _isGrabbing;

        public float approachRate = 10f;

        private PlayerInput _controls;

        public override void OnStartLocalPlayer()
        {
            _controls = new PlayerInput();
            _controls.Enable();
            _controls.Player.Grab.performed += ctx => OnGrab();
        }

        private void FixedUpdate()
        {
            if (!_isGrabbing) return;

            MoveItem();
        }

        private void MoveItem()
        {
            _itemRb.velocity = (grabPos.position - _item.transform.position) * approachRate;

            _item.transform.rotation = grabPos.rotation;
        }

        private void OnGrab()
        {
            if (_item is null)
                GrabItem();
            else
                ReleaseItem();
        }

        private void ReleaseItem()
        {
            _isGrabbing = false;

            _itemRb.useGravity = true;
            _item = null;
            _itemRb = null;
        }

        private void GrabItem()
        {
            if (Camera.main is null) return;
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (!Physics.Raycast(ray, out var hit, 2f)) return;
            if (!hit.transform.gameObject.CompareTag("Item")) return;

            _item = hit.transform.gameObject;
            _itemRb = _item.GetComponent<Rigidbody>();
            _itemRb.useGravity = false;

            _isGrabbing = true;

            Debug.Log(_item.name + " hit!");
        }
    }
}