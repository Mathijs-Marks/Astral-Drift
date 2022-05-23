using UnityEngine;
using UnityEngine.Events;

public class PlayerHitEvent : MonoBehaviour
{
    private UnityEvent playerHit;
    private Health playerHealth;
    void Start()
    {
        if (playerHit == null)
            playerHit = new UnityEvent();

        playerHealth = GetComponent<Health>();
        playerHit.AddListener(PlayerGotHit);
    }
    private void PlayerGotHit()
    {
        if (playerHealth.CurrentHitpoints <= 0)
        {
            UI.instance.UpdateHitpoints(playerHealth.CurrentHitpoints);
            GameOverHandler.instance.GameOver();
        }
        else
            UI.instance.UpdateHitpoints(playerHealth.CurrentHitpoints);
    }
}
