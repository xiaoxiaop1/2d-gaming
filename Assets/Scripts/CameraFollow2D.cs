using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = false;

    [Header("Camera Bounds")]
    [SerializeField] private bool useXBounds = true;
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private Vector3 offset;

    private void Start()
    {
        if (target == null)
        {
            return;
        }

        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 newPosition = transform.position;

        if (followX)
        {
            newPosition.x = target.position.x + offset.x;
        }

        if (followY)
        {
            newPosition.y = target.position.y + offset.y;
        }

        if (useXBounds)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        }

        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}