using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;
    private float yOffset;

    void Start()
    {
        yOffset = transform.position.y - target.position.y;
    }

    void LateUpdate()
    {
        if (target.position.y > transform.position.y - yOffset)
        {
            float newPosY = Mathf.SmoothStep(transform.position.y, target.position.y + yOffset, smoothSpeed);
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
    }
}
