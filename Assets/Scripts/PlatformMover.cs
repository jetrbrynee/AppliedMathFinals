using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float range = 2f;
    public float frequency = 1f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        //Move the platform pattern using Mathf.Cos
        transform.position = startPosition + Vector3.right * Mathf.Cos(Time.time * frequency) * range;
    }
}
