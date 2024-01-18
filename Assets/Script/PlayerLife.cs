using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSoundEffect;
    public float bounceForce = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        // Disable further collisions and interactions
        GetComponent<Collider2D>().enabled = false;

        // Apply a vertical force to simulate a bounce
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

        // Perform other death-related actions if needed

        // For example, you might want to trigger a game over screen or respawn logic
        // after a certain delay.
        StartCoroutine(GameOverRoutine());
    }

    private void Bounce()
    {
        // Apply a vertical force to simulate a bounce
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(1.5f); // Adjust the delay as needed

        // Implement your game over logic here
        // For example, you could load a game over scene or reset the level.
        Debug.Log("Game Over!");
    }

    void Update()
    {
        // Add any additional update logic if needed
    }
}
