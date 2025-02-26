using UnityEngine;
using TMPro;

public class Eastscoredisplay : MonoBehaviour
{
    private TextMeshProUGUI textTMP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            textTMP.SetText(EastScoreText.eastscore.ToString());
        }
    }
}
