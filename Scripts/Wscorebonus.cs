using UnityEngine;
using TMPro;

public class Wscorebonus : MonoBehaviour
{
    public static int wbonus;
    private TextMeshProUGUI textTMP;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}
    void Start()
    {
        wbonus = 0;
        textTMP = GetComponent<TextMeshProUGUI>();
        if (textTMP == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on GameObject.");
        }
    }

    void Update()
    {
        if (Wscore.wscore >= 3)
{
    wbonus = (Wscore.wscore - 3) / 3 * 5 + 5;
}
else
{
    wbonus = 0;
}

        if (textTMP != null)
        {
            textTMP.SetText(wbonus.ToString());
        }
    }
}