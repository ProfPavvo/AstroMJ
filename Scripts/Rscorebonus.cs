using UnityEngine;
using TMPro;

public class Rscorebonus : MonoBehaviour
{
    public static int rbonus;
    private TextMeshProUGUI textTMP;

    //private void Awake()
    //{
    //   DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}
    
    void Start()
    {
        rbonus = 0;
        textTMP = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Rscore.rscore >= 3)
        {
            rbonus = ((Rscore.rscore - 3) / 3) * 5 + 5;
        }
        else
        {
            rbonus = 0;
        }

        if (textTMP != null)
        {
            textTMP.SetText(rbonus.ToString());
        }
    }
}