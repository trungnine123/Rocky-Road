using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 10f; // Adjust the force to control the height of the bounce
    public Animator animator; // Reference to the Animator component

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Assuming the player has a Rigidbody2D component
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Apply the bounce force vertically
                playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);

                // Trigger the bounce animation if an Animator is attached
                if (animator != null)
                {
                    animator.SetTrigger("Bounce");
                }
            }
        }
    }
}
