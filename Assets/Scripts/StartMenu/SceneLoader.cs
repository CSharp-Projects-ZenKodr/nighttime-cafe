using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartMenu
{
    public class SceneLoader : MonoBehaviour
    {
        private const string PlayerPrefsNicknameKey = "Nickname";
        private const string PlayerPrefsIPKey = "IP";
        private const string PlayerPrefsConnectionKey = "Connection";

        public TMP_InputField nicknameInputField;
        public TMP_InputField ipInputField;

        private void Start()
        {
            SetUpNicknameField();
            SetUpIPField();
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

        private void SetPreferences()
        {
            PlayerPrefs.SetString(PlayerPrefsNicknameKey, nicknameInputField.text);
            PlayerPrefs.SetString(PlayerPrefsIPKey, ipInputField.text);
        }

        [UsedImplicitly]
        public void OnHost()
        {
            SetPreferences();
            
            PlayerPrefs.SetString(PlayerPrefsConnectionKey, "Host");
            
            // changing scene
            SceneManager.LoadScene("Main");
        }
    }
}
