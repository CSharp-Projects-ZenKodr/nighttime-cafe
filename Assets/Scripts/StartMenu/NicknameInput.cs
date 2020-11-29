using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class NicknameInput : MonoBehaviour
    {
        private const string PlayerPrefsNameKey = "Nickname";

        public TMP_InputField inputField;

        public static string DisplayName { get; private set; }

        private void Start()
        {
            SetUpInputField();
        }

        private void SetUpInputField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) return;

            var defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);
            inputField.text = defaultName;
        }

        [UsedImplicitly]
        public void SetNickname()
        {
            DisplayName = inputField.text;

            PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
        }
    }
}