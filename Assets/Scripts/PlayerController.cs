using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float movementSpeed = 5f;
    public float oscillationAmplitude = 0.5f;
    public float oscillationFrequency = 2f;
    private Rigidbody2D rb;
    private float originalY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalY = transform.position.y;
    }

    void Update()
    {
        // Horizontal Movement with Oscillation
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float oscillation = Mathf.Sin(Time.time * oscillationFrequency) * oscillationAmplitude;
        transform.position += new Vector3(hMovement, oscillation, 0) * Time.deltaTime;

        // Limiting the player's horizontal position with Mathf.Clamp
        float limitedX = Mathf.Clamp(transform.position.x, -5f, 5f);
        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce the player upwards with some added 'juice' using Mathf.LerpUnclamped
        if (collision.relativeVelocity.y <= 0f)
        {
            float bounce = Mathf.LerpUnclamped(jumpForce, jumpForce * 1.1f, Mathf.InverseLerp(0, originalY, transform.position.y));
            rb.velocity = Vector2.up * bounce;
        }
    }
}
