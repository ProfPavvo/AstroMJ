using UnityEngine;
using TMPro;

public class Rscore : MonoBehaviour
{
    public static int rscore;
    private TextMeshProUGUI textTMP;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}

    // Start is called before the first frame update
    void Start()
    {
        rscore = 0;
        textTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textTMP != null)
        {
            textTMP.SetText(rscore.ToString());
        }
    }
}