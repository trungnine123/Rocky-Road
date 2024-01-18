using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private ParticleSystem runParticle;

    private bool isGrounded;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimator();
        FlipCharacter();
        UpdateParticle();
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void UpdateAnimator()
    {
        float speed = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", speed);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void FlipCharacter()
    {
        if (rb.velocity.x > 0.1f)
        {
            spriteRenderer.flipX = true; // face right
        }
        else if (rb.velocity.x < -0.1f)
        {
            spriteRenderer.flipX = false; // face left
        }
    }

    private void UpdateParticle()
    {
        // Check if the player is on the ground and moving
        if (isGrounded && Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            // Play particle effect
            if (!runParticle.isPlaying)
            {
                runParticle.Play();
            }
        }
        else
        {
            // Stop particle effect
            if (runParticle.isPlaying)
            {
                runParticle.Stop();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character is grounded (e.g., colliding with the ground layer)
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Update the grounded status when leaving the ground
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}
