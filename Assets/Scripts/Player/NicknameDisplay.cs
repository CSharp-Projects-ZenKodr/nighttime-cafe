using Mirror;
using UnityEngine;

namespace Player
{
    public class NicknameDisplay : NetworkBehaviour
    {
        public TextMesh nicknameField;
        public Transform floatingData;
        private Camera _camera;

        [SyncVar(hook = nameof(OnNameChanged))] public string nickname;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        public override void OnStartClient()
        {
            CmdSetupNickname(PlayerPrefs.GetString("Nickname"));
        }

        private void Update()
        {
            if (isLocalPlayer) return;
            floatingData.LookAt(_camera.transform);
        }
        
        private void OnNameChanged(string old, string @new)
        {
            nicknameField.text = nickname;
        }

        [Command]
        private void CmdSetupNickname(string value)
        {
            nickname = value;
        }
    }
}
