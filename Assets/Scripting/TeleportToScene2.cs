using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene2 : MonoBehaviour
{
    public string sceneName = "Room2";

    public void Teleport()
    {
        SceneManager.LoadScene(sceneName);
    }
}
