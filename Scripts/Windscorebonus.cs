using UnityEngine;
using TMPro;

public class Windscorebonus : MonoBehaviour
{
    public static int windbonus;
    private TextMeshProUGUI textTMP;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}
    void Start()
    {
        windbonus = 0;
        textTMP = GetComponent<TextMeshProUGUI>();
        if (textTMP == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on GameObject.");
        }
    }

    void Update()
    {
        int[] scores = { Northscore.northscore, Southscore.southscore, EastScoreText.eastscore, Westscore.westscore };

        for (int targetScore = 1; ; targetScore++) // Loop indefinitely, checking for increasing target scores
        {
            bool allScoresMeetMinimum = true;
            bool targetScoreExists = false;

            foreach (int score in scores)
            {
                if (score < targetScore)
                {
                    allScoresMeetMinimum = false;
                    break; // No need to continue checking if one score is too low
                }

                if (score == targetScore)
                {
                    targetScoreExists = true;
                }
            }

            if (allScoresMeetMinimum)
            {
                if (targetScoreExists)
                {
                    windbonus = targetScore * 10;
                }
                else
                {
                    // If all scores are greater than or equal to the target score, but none are
                    // equal to the target score, then continue to the next iteration.
                    continue;
                }
            }
            else
            {
                break; // Stop checking if not all scores meet the minimum
            }
        }

        if (textTMP != null)
        {
            textTMP.SetText(windbonus.ToString());
        }
    }
}