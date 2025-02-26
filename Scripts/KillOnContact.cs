using UnityEngine;

public class KillOnContact : MonoBehaviour
{
    public AudioClip collisionSound; // The sound file to play on collision with the Player
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ensure the AudioSource is enabled before playing the sound
            if (audioSource != null && collisionSound != null)
            {
                audioSource.enabled = true;
                audioSource.PlayOneShot(collisionSound);
            }

            // Send kill message to player
            collision.gameObject.SendMessage("Kill");
        }
    }
}