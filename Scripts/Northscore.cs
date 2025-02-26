using UnityEngine;
using TMPro;

public class Northscore: MonoBehaviour
{
    public static int northscore;
    private TextMeshProUGUI textTMP;

    // Start is called before the first frame update
    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}


    void Start()
    {
        northscore = 0;
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
            textTMP.SetText(northscore.ToString());
        }
    }
}