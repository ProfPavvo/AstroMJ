using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on bullet prefab.");
        }
    }

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the bullet after a certain time
    }

    public void Initialize(Vector2 direction)
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
            
        }
        else
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EBullet"))
        {
            Destroy(gameObject);
        }
    }
}
