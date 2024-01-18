using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float bounceHeight = 0.5f; // Adjust this value based on the desired bounce height
    private Transform player;
    private Animator animator;
    private bool isBouncing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Move towards the player with bouncing motion
        MoveWithBounce();

        // Check for player contact
        CheckForPlayerContact();
    }

    private void MoveWithBounce()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            // Update the Animator parameters to control the animation
            //animator.SetFloat("MoveX", direction.x);
            //animator.SetFloat("MoveY", direction.y);

            if (!isBouncing)
            {
                // Apply the regular movement
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Apply the bouncing motion
                float bounceOffset = Mathf.Sin(Time.time * 5) * bounceHeight;
                transform.Translate(direction * moveSpeed * Time.deltaTime + new Vector2(0, bounceOffset));
            }
        }
    }

    private void CheckForPlayerContact()
    {
        // Assuming the player has a Collider2D component
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            // Check for contact with the player
            if (GetComponent<Collider2D>().IsTouching(playerCollider))
            {
                // Player is dead
                KillPlayer();
            }
        }
    }

    private void KillPlayer()
    {
        // Implement player death logic here
        Debug.Log("Player is dead!");
        // You can add more actions like game over screen, respawn logic, etc.
    }

    // Add a public method to start the bouncing motion (e.g., when the slime hits a wall)
    public void StartBounce()
    {
        isBouncing = true;
    }

    // Add a public method to stop the bouncing motion
    public void StopBounce()
    {
        isBouncing = false;
    }
}
