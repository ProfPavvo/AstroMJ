using UnityEngine;

public class LifeCount : MonoBehaviour
{
public int lifeNumber;
// Update is called once per frame
void Update()
{
// Deactivate the object when the player has fewer than
// lifeNumber lives
if (Astromove.lives < lifeNumber)
{
gameObject.SetActive(false);
}
}
}