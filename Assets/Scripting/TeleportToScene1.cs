using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene1 : MonoBehaviour
{
    public string sceneName = "Room1";

    public void Teleport()
    {
        SceneManager.LoadScene(sceneName);
    }
}
