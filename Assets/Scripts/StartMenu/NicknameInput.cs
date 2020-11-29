using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class NicknameInput : MonoBehaviour
    {
        private const string PlayerPrefsNameKey = "Nickname";

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
    }
}