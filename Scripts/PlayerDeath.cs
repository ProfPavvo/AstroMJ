using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Timer timerScript; // Reference to the Timer script

    private void Die()
    {
        // Create the explosion effect at the player's position
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        // Delete the explosion after 1 second
        Destroy(explosion, 1);
        // Delete the player
        Destroy(gameObject);
        // Set the timeRemaining variable in the Timer script to 1
        timerScript.timeRemaining = 1f;
        // Start coroutine to load the ScoreScreen scene after 1 second
    //    StartCoroutine(LoadScoreScreenAfterDelay(1f));
    }

    //private IEnumerator LoadScoreScreenAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene("ScoreScreen");
    //}

    void Update()
    {
    }
}