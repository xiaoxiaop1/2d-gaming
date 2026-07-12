using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public enum MoveMode
    {
        HorizontalOnly,
        FourDirections
    }

    [SerializeField] private MoveMode moveMode = MoveMode.FourDirections;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Collider2D movementBounds;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput.x = -1f;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput.x = 1f;
        }

        if (moveMode == MoveMode.FourDirections)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                moveInput.y = 1f;
            }
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                moveInput.y = -1f;
            }
        }

        moveInput = moveInput.normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        if (movementBounds != null)
        {
            Bounds bounds = movementBounds.bounds;
            Vector2 clampedPosition = rb.position;

            clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.min.x, bounds.max.x);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.min.y, bounds.max.y);

            rb.position = clampedPosition;
        }
    }

    public void SetMovementBounds(Collider2D bounds)
    {
        movementBounds = bounds;
    }

    public void ClearMovementBounds()
    {
        movementBounds = null;
    }
}