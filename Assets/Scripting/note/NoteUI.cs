using UnityEngine;
using TMPro;

public class NoteUI : MonoBehaviour
{
    public static NoteUI Instance;

    [Header("UI References")]
    public GameObject root;     // The panel window
    public TMP_Text titleText;
    public TMP_Text bodyText;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Hide();
    }

    public void Show(string title, string body)
    {
        root.SetActive(true);

        titleText.text = title;
        bodyText.text = body;

        // Optional: pause gameplay while reading
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        root.SetActive(false);

        // Resume game
        Time.timeScale = 1f;
    }
}
