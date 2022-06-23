using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickupable
{
    [SerializeField] private int addedHealthPoints = 20;

    public override void OnPickUp(Collider2D collision)
    {
        base.OnPickUp(collision);

        GlobalReferenceManager.PlayerHealthScript.Heal(addedHealthPoints);
    }
}
