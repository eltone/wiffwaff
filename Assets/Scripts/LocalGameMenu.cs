using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;

public class LocalGameMenu : MonoBehaviour
{
    public void HostGame()
    {
        SceneManager.LoadScene("Game");
        GameManager.Instance.IsHost = true;
    }

    public void JoinGame()
    {
        SceneManager.LoadScene("Game");
        //NetworkingManager.Singleton.StartClient();
    }
}
