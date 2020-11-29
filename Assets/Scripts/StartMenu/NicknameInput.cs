using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class NicknameInput : MonoBehaviour
    {
        private const string PlayerPrefsNameKey = "Nickname";
        public string Nickname { get; private set; }

        public TMP_InputField inputField;

        private void Start()
        {
            SetUpInputField();
        }

        private void SetUpInputField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) return;

            inputField.text = PlayerPrefs.GetString(PlayerPrefsNameKey);
        }

        [UsedImplicitly]
        public void OnSetNickname()
        {
            Nickname = inputField.text;
            
            PlayerPrefs.SetString(PlayerPrefsNameKey, Nickname);
        }
    }
}