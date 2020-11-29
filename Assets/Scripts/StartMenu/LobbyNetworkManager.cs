using Mirror;
using UnityEngine.SceneManagement;

namespace StartMenu
{
    public class LobbyNetworkManager : NetworkManager
    {
        public void OnHost()
        {
            SceneManager.LoadScene("Main");
            StartHost();
        }

        public void OnClient()
        {
            SceneManager.LoadScene("Main");
            StartClient();
        }
    }
}
