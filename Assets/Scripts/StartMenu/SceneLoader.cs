using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StartMenu
{
    public class SceneLoader : MonoBehaviour
    {
        private const string PlayerPrefsNicknameKey = "Nickname";
        private const string PlayerPrefsIPKey = "IP";

        public TMP_InputField nicknameInputField;
        public TMP_InputField ipInputField;

        public Button hostButton;
        public Button joinButton;

        private void Start()
        {
            SetUpNicknameField();
            SetUpIPField();

            hostButton.onClick.AddListener(OnHost);
            joinButton.onClick.AddListener(OnJoin);
        }

        private void SetUpNicknameField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsNicknameKey)) return;

            nicknameInputField.text = PlayerPrefs.GetString(PlayerPrefsNicknameKey);
        }

        private void SetUpIPField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsIPKey)) return;

            ipInputField.text = PlayerPrefs.GetString(PlayerPrefsIPKey);
        }

        private void OnHost()
        {
            PlayerPrefs.SetString(PlayerPrefsNicknameKey, nicknameInputField.text);

            NetworkManager.singleton.StartHost();
        }

        private void OnJoin()
        {
            PlayerPrefs.SetString(PlayerPrefsNicknameKey, nicknameInputField.text);
            PlayerPrefs.SetString(PlayerPrefsIPKey, ipInputField.text);

            try
            {
                NetworkManager.singleton.networkAddress = PlayerPrefs.GetString(PlayerPrefsIPKey);
                NetworkManager.singleton.StartClient();
            }
            catch
            {
                Debug.Log("Invalid IP!");
            }
        }
    }
}