using UnityEngine;

public class SpriteContactSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip touchSound;

    // Detects physical impacts (solid objects hitting each other)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayContactSound();
        }
    }

    // Detects overlaps (when "Is Trigger" is checked)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayContactSound();
        }
    }

    // Private helper so we don't repeat the play logic
    private void PlayContactSound()
    {
        if (audioSource != null && touchSound != null)
        {
            audioSource.PlayOneShot(touchSound);
        }
    }
}