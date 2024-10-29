using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;     // Force applied to jump
    private Rigidbody rb;
    private bool isGrounded = false; // Flag to check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for jump input and if the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply upward force to the Rigidbody for jumping
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        isGrounded = false; // Set isGrounded to false until we land again
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if we hit the ground by checking the tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // If the player leaves the ground, set isGrounded to false
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
