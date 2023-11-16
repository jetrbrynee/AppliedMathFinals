using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; //Control the jump force
    public float movementSpeed = 5f; //Control the horizontal movement speed
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Get the Rigidbody2D component attached to this GameObject
    }

    void Update()
    {
        //Horizontal Movement
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed;
        transform.position += new Vector3(hMovement, 0f, 0f) * Time.deltaTime;

        //Limiting the player's horizontal position with Mathf.Clamp
        float limitedX = Mathf.Clamp(transform.position.x, -10f, 10f); // For side to side boundary
        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Bounce the player upwards only when falling down (velocity.y <= 0) and if the player hits a platform
        if (collision.gameObject.CompareTag("Platform") && rb.velocity.y <= 0f)
        {
            rb.velocity = Vector2.up * jumpForce; // upward force to the player's Rigidbody2D
        }
    }
}
