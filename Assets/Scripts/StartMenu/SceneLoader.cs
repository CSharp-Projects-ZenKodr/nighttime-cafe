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

        private static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        private static string GetPrefsValue(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        private void SetUpNicknameField()
        {
            if (!HasKey(PlayerPrefsNicknameKey)) return;

            nicknameInputField.text = GetPrefsValue(PlayerPrefsNicknameKey);
        }

        private void SetUpIPField()
        {
            if (!HasKey(PlayerPrefsIPKey)) return;

            ipInputField.text = GetPrefsValue(PlayerPrefsIPKey);
        }

        [UsedImplicitly]
        public void OnHost()
        {
            // haha yes dirty data pass
            PlayerPrefs.SetString(PlayerPrefsConnectionKey, "Host");
            
            // changing scene
            SceneManager.LoadScene("Main");
        }
    }
}
