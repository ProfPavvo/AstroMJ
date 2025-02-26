using UnityEngine;

public class GEnemyDeath : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip deathSound; // The sound file to play when the enemy is destroyed
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Delete the explosion after 1 second
            Gscore.gscore = Gscore.gscore + 1;
            Destroy(explosion, 1);

            // Play the death sound
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            Destroy(gameObject);
        }
    }
}
