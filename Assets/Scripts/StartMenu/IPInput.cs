using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class IPInput : MonoBehaviour
    {
        private const string PlayerPrefsIPKey = "IP";
        public string IP { get; private set; }

        public TMP_InputField inputField;

        private void Start()
        {
            SetUpIPField();
        }

        private void SetUpIPField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsIPKey)) return;

            inputField.text = PlayerPrefs.GetString(PlayerPrefsIPKey);
        }

        [UsedImplicitly]
        public void OnSetIP()
        {
            IP = inputField.text;
            
            PlayerPrefs.SetString(PlayerPrefsIPKey, IP);
        }
    }
}