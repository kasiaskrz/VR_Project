using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToMainScene : MonoBehaviour
{
    public string sceneName = "SampleScene";

    public void TeleportBack()
    {
        SceneManager.LoadScene(sceneName);
    }
}
