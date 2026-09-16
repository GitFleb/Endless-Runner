using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public float deathY = -10f;
    public DeathManager deathManager;


    void Update()
    {
        if (transform.position.y < deathY)
        {
            if (deathManager != null)
            {
                deathManager.ShowDeathScreen();
            }

            else Debug.Log("DeathManager not assigned!");
        }
    }
}