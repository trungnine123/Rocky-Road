using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collectSoundEffect.Play();
            CollectItem(collision.gameObject);
        }
    }

    private void CollectItem(GameObject item)
    {
        // Add your item collection logic here
        // For example, you can play a sound, update the score, or perform any other actions.

        // Access the Animator component on the collected item (coin in this case)
        Animator itemAnimator = item.GetComponent<Animator>();

        // Trigger the animation on the collected item
            if (itemAnimator != null)
            {
                itemAnimator.SetTrigger("Collect");
            }

        // Destroy the collected item (coin in this case)
        Destroy(item);
    }
}
