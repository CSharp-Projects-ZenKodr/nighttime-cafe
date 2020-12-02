using Mirror;

namespace Player
{
    public class PropsGrab : NetworkBehaviour
    {
        public bool IsGrabbing { get; private set; }

        public override void OnStartLocalPlayer()
        {
            IsGrabbing = false;
        }
    }
}