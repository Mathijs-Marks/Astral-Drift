using UnityEngine;

public class ShootingSpeedPickupable : Pickupable
{
    // Upgrade value for player
    [SerializeField] private float shootingSpeedUpgradePercentage;

    public override void OnPickUp(Collider2D collision)
    {
        base.OnPickUp(collision);

        if (UI.instance.currentUpgrade < UI.instance.maxUpgrade)
        {
            // Update UI
            UI.instance.ShootingSpeedUpgrade();

            // Increase shooting rate in player
            collision.GetComponent<Player>().InscreaseShootingSpeed(shootingSpeedUpgradePercentage);
        }
    }
}

