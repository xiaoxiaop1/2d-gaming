using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ScenePortal : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private GameObject promptObject;

    private bool playerInRange;

    private void Start()
    {
        if (promptObject != null)
        {
            promptObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!playerInRange)
        {
            return;
        }

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerInRange = true;

        if (promptObject != null)
        {
            promptObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerInRange = false;

        if (promptObject != null)
        {
            promptObject.SetActive(false);
        }
    }
}