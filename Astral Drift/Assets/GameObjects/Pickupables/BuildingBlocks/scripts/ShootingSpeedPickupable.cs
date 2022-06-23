using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeedPickupable : Pickupable
{
    [SerializeField] private float shootingSpeedUpgradeAmount;

    public override void OnPickUp(Collider2D collision)
    {
        base.OnPickUp(collision);

        if (UI.instance.currentUpgrade < UI.instance.maxUpgrade)
        {
            UI.instance.ShootingSpeedUpgrade();

            collision.GetComponent<Player>().InscreaseShootingSpeed(shootingSpeedUpgradeAmount);
        }
    }
}

