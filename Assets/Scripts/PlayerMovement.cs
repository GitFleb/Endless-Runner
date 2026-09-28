using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;        // Constant Forward speed
    public float jumpForce = 10f;       // Jump Force
    public Transform groundCheckPoint;  // A point to check if the player is grounded
    public float checkRadius = 0.2f;    // Radius of the overlap circle for ground detection
    public LayerMask groundLayer;       // Layer of the ground objects
    public GameObject player;          // Reference to the Player GameObject

    private Rigidbody2D rb;             // Reference to the Rigidbody2D Component
    private bool isGrounded;            // Is the player on the ground?
    Animator anim;

    public float dashForce = 15f; // Dash Force

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // Get the Rigidbody2D component attached to the player
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Constant forward movement
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            //player.IgnoreGravity = true;
            rb.linearVelocity = new Vector2(dashForce, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(movespeed, rb.linearVelocity.y);
        }

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        // jumping Logic
        if (isGrounded && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        anim.SetBool("isOnGround", isGrounded);
 
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            Dash();
        }

    }
    
    private void Dash()
    {
        //rb.linearVelocity = new Vector2(dashForce, rb.linearVelocity.y);
        Debug.Log("Dashed");
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
    
    