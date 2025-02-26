using UnityEngine;
using TMPro;

public class Westscore: MonoBehaviour
{
    public static int westscore;
    private TextMeshProUGUI textTMP;

    // Start is called before the first frame update
    
    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}

    void Start()
    {
        westscore = 0;
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
            textTMP.SetText(westscore.ToString());
        }
    }
}