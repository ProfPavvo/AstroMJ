using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f;
    private TextMeshProUGUI textTMP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            UpdateTimerDisplay();
            SceneManager.LoadScene("ScoreScreen");
        }
    }

    private void UpdateTimerDisplay()
    {
        if (textTMP != null)
        {
            textTMP.SetText(Mathf.Ceil(timeRemaining).ToString());
        }
    }
}
