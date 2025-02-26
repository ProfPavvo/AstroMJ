using UnityEngine;
using TMPro;

public class Finalscore : MonoBehaviour
{
    private int finalScore;
    private TextMeshProUGUI textTMP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalScore = Rscore.rscore + Gscore.gscore + Wscore.wscore + EastScoreText.eastscore + Westscore.westscore + Northscore.northscore + Southscore.southscore + Rscorebonus.rbonus + Gscorebonus.gbonus + Wscorebonus.wbonus + Windscorebonus.windbonus;
        textTMP = GetComponent<TextMeshProUGUI>();
        if (textTMP == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textTMP != null)
        {
            textTMP.SetText(finalScore.ToString());
        }
    }
}
