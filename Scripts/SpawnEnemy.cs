using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public AudioClip specialEnemySound; // The sound to play when the special enemy is spawned
    private AudioSource audioSource;

    private void Start()
    {
        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned.");
        }
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point not assigned.");
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (IsSpawnPointEmpty())
            {
                SpawnRandomEnemy();
            }
        }
    }

    private bool IsSpawnPointEmpty()
    {
        if (spawnPoint == null)
        {
            return false;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, 0.1f);
        return colliders.Length == 0;
    }

    private void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Length > 0 && spawnPoint != null)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0);

            // Check if the spawned enemy is one of the special enemies and play the sound
            if (enemy.name.Contains("WEnemy") || enemy.name.Contains("Red Enemy 1") || enemy.name.Contains("GreenEnemy")) // Replace with the names of your special enemy prefabs
            {
                if (audioSource != null && specialEnemySound != null)
                {
                    audioSource.PlayOneShot(specialEnemySound);
                }
            }
        }
    }
}
