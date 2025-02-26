using UnityEngine;
using System.Collections;

public class EnemyBulletBehavior : MonoBehaviour
{
    public float lifetime = 5f;
    private bool collided = false;
    private Renderer bulletRenderer;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        bulletRenderer = GetComponent<Renderer>();
        if (bulletRenderer == null)
        {
            Debug.LogError("Renderer component not found on the bullet!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collided) return;
        collided = true;

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(VanishAndDestroy());
        }
    }

    private IEnumerator VanishAndDestroy()
    {
        if (bulletRenderer != null)
        {
            bulletRenderer.enabled = false; // Make the bullet invisible
        }

        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        Destroy(gameObject);
    }
}