using UnityEngine;

public class EastEnemyDeath : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Delete the explosion after 1 second
            EastScoreText.eastscore = EastScoreText.eastscore + 1;
            Destroy(explosion, 1);
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
