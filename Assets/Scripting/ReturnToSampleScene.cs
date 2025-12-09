using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ReturnToSampleScene : MonoBehaviour
{
    // Input Action reference (from XRI Default Input Actions)
    public InputActionProperty buttonX;

    private void Update()
    {
        if (buttonX.action != null && buttonX.action.WasPressedThisFrame())
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
