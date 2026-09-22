using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;        // Constant Forward speed
    public float jumpForce = 10f;       // Jump Force
    public Transform groundCheckPoint;  // A point to check if the player is grounded
    public float checkRadius = 0.2f;    // Radius of the overlap circle for ground detection
    public LayerMask groundLayer;       // Layer of the ground objects

    private Rigidbody2D rb;             // Reference to the Rigidbody2D Component
    private bool isGrounded;            // Is the player on the ground?
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // Get the Rigidbody2D component attached to the player
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Constant forward movement
        rb.linearVelocity = new Vector2(movespeed, rb.linearVelocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        // jumping Logic
        if (isGrounded && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        anim.SetBool("isOnGround", isGrounded);
    }   


    private void Jump()
    {
        // Set upward velocity for jumping
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }


    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualise the ground check point in the editor
        if (groundCheckPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }
}   
    
    