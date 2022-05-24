using UnityEngine;
using UnityEngine.Events;

public class PlayerHitEvent : MonoBehaviour
{
    private UnityEvent playerHit;
    private PlayerHealth playerHealth;
    void Start()
    {
        if (playerHit == null)
            playerHit = new UnityEvent();

        playerHealth = GetComponent<PlayerHealth>();
        playerHit.AddListener(PlayerGotHit);
    }
    private void PlayerGotHit()
    {
        if (playerHealth.CurrentHitpoints <= 0)
        {
            UI.instance.UpdateHitpoints();
            GameOverHandler.instance.GameOver();
        }
        else
            UI.instance.UpdateHitpoints();
    }
}
