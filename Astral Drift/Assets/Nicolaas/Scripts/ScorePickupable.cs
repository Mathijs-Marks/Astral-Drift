using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 1;

    protected override void PickUp(Collider2D collision)
    {
        base.PickUp(collision);

        UI.instance.AddScore(scoreIncrease);
    }
}
