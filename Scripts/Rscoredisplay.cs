using UnityEngine;
using TMPro;

public class Rscoredisplay : MonoBehaviour
{
    private TextMeshProUGUI textTMP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textTMP != null)
        {
            textTMP.SetText(Rscore.rscore.ToString());
        }
    }
}
