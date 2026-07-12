using UnityEngine;
using UnityEngine.InputSystem;

public class MedicineCabinetInteraction : MonoBehaviour
{
    [SerializeField] private GameObject cabinetPanel;

    private bool playerInRange;

    private void Start()
    {
        if (cabinetPanel != null)
        {
            cabinetPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (playerInRange && Keyboard.current.fKey.wasPressedThisFrame)
        {
            OpenCabinetPanel();
        }

        if (cabinetPanel != null &&
            cabinetPanel.activeSelf &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            CloseCabinetPanel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerInRange = false;
    }

    private void OpenCabinetPanel()
    {
        if (cabinetPanel != null)
        {
            cabinetPanel.SetActive(true);
        }
    }

    private void CloseCabinetPanel()
    {
        if (cabinetPanel != null)
        {
            cabinetPanel.SetActive(false);
        }
    }
}