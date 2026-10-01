using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Constant Forward speed
    public float jumpForce = 10f;       // Jump Force
    public Transform groundCheckPoint;  // A point to check if the player is grounded
    public float checkRadius = 0.2f;    // Radius of the overlap circle for ground detection
    public LayerMask groundLayer;       // Layer of the ground objects
    public GameObject player;           // Reference to the Player GameObject

    private Rigidbody2D rb;             // Reference to the Rigidbody2D Component
    [SerializeField] public bool isGrounded;
    private int jumpCount = 0;          // Count of jumps made by the player
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // Get the Rigidbody2D component attached to the player
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Constant forward movement
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        // jumping Logic
        if (isGrounded && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame || jumpCount <= 2 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
            jumpCount = jumpCount + 1;
           if (isGrounded)
            {
                jumpCount = 0; // Reset jump count after double jump
            } 
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