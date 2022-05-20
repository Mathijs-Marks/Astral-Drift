using UnityEngine.Events;

public class PlayerHealth : Health
{
    protected UnityEvent playerHit, playerDeath;
    public override void TakeDamage(int damage)
    {
        currentHitpoints -= damage;
        playerHit.Invoke();
        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            playerDeath.Invoke();
        }
    }
}
