using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NotePickup : MonoBehaviour
{
    [Header("Note Info")]
    public string noteTitle;

    [TextArea(3, 10)]
    public string noteBody;

    [Header("Settings")]
    public bool destroyOnPickup = true;
    public KeyCode interactKey = KeyCode.E;

    private bool isPlayerInRange;

    private void Reset()
    {
        // Ensure trigger collider
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = false;
    }

    private void Update()
    {
        if (!isPlayerInRange) return;

        if (Input.GetKeyDown(interactKey))
        {
            NoteUI.Instance.Show(noteTitle, noteBody);

            if (destroyOnPickup)
                Destroy(gameObject);
        }
    }
}
