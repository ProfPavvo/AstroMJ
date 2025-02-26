using UnityEngine;
using TMPro;

public class Gscorebonus : MonoBehaviour
{
    public static int gbonus;
    private TextMeshProUGUI textTMP;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Prevent score from resetting when another scene is loaded
    //}
    void Start()
    {
        gbonus = 0;
        textTMP = GetComponent<TextMeshProUGUI>();
        if (textTMP == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on GameObject.");
        }
    }

    void Update()
    {
        if (Gscore.gscore >= 3)
{
    gbonus = (Gscore.gscore - 3) / 3 * 5 + 5;
}
else
{
    gbonus = 0;
}

        if (textTMP != null)
        {
            textTMP.SetText(gbonus.ToString());
        }
    }
}