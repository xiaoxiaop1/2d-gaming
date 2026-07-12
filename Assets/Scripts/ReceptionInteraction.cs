using UnityEngine;
using UnityEngine.InputSystem;

public class ReceptionInteraction : MonoBehaviour
{
    [SerializeField] private Collider2D receptionAreaBounds;
    [SerializeField] private GameObject endReceptionButton;

    private PlayerController2D player;
    private bool playerInRange;
    private bool receptionStarted;

    private void Start()
    {
        if (endReceptionButton != null)
        {
            endReceptionButton.SetActive(false);
        }
    }

    private void Update()
    {
        if (receptionStarted)
        {
            return;
        }

        if (!playerInRange)
        {
            return;
        }

        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            StartReception();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        player = other.GetComponent<PlayerController2D>();
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

    private void StartReception()
    {
        if (player == null || receptionAreaBounds == null)
        {
            return;
        }

        receptionStarted = true;
        player.SetMovementBounds(receptionAreaBounds);

        if (endReceptionButton != null)
        {
            endReceptionButton.SetActive(true);
        }
    }

    public void EndReception()
    {
        if (player != null)
        {
            player.ClearMovementBounds();
        }

        receptionStarted = false;

        if (endReceptionButton != null)
        {
            endReceptionButton.SetActive(false);
        }
    }
}