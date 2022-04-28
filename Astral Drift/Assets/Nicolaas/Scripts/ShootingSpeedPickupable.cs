using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeedPickupable : Pickupable
{
    [SerializeField] private float shootingSpeedUpgradeAmount;

    protected override void PickUp()
    {
        base.PickUp();

        UI.instance.ShootingSpeedUpgrade(shootingSpeedUpgradeAmount);
    }
}

