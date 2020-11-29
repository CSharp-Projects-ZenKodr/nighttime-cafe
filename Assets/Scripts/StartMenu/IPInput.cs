using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class IPInput : MonoBehaviour
    {
        private const string PlayerPrefsIPKey = "IP";

        public TMP_InputField inputField;
        
        public static string DisplayIP { get; private set; }

        private void Start()
        {
            SetUpIPField();
        }

        private void SetUpIPField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsIPKey)) return;

            var defaultIP = PlayerPrefs.GetString(PlayerPrefsIPKey);
            inputField.text = defaultIP;
        }

        [UsedImplicitly]
        public void SetIP()
        {
            DisplayIP = inputField.text;
            
            PlayerPrefs.SetString(PlayerPrefsIPKey, DisplayIP);
        }
    }
}
