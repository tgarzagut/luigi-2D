using UnityEngine;

public class CameraFollowAutoBounds : MonoBehaviour
{
    public Transform target; 
    public SpriteRenderer backgroundRenderer; 
    public float smoothSpeed = 0.125f;

    private float camHalfHeight;
    private float camHalfWidth;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        if (target == null || backgroundRenderer == null)
        {
            Debug.LogError("Missing target or backgroundRenderer reference.");
            return;
        }

        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;

        Bounds bgBounds = backgroundRenderer.bounds;
        minBounds = bgBounds.min;
        maxBounds = bgBounds.max;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        float clampedX = Mathf.Clamp(desiredPos.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPos.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, transform.position.z), smoothSpeed);
        transform.position = smoothedPosition;
    }
}
