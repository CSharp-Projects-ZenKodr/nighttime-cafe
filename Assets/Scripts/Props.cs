using Mirror;
using Player;
using UnityEngine;

public class Props : NetworkBehaviour
{
    private Rigidbody _rb;
    public GameObject player;
    private PropsGrab _propsGrab;

    private void Start()
    {
        _propsGrab = player.GetComponent<PropsGrab>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_propsGrab.IsGrabbing)
            _rb.AddForce(Vector3.down * 0.2f, ForceMode.Force);
    }
}
