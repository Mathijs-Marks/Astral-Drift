using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeedPickupable : Pickupable
{
    [SerializeField] private float shootingSpeedUpgradeAmount;

    protected override void PickUp(Collider2D collision)
    {
        base.PickUp(collision);

        if (UI.instance.currentUpgrade < UI.instance.maxUpgrade)
        {
            UI.instance.ShootingSpeedUpgrade();

            collision.GetComponent<Player>().InscreaseShootingSpeed(shootingSpeedUpgradeAmount);
        }
    }
}

