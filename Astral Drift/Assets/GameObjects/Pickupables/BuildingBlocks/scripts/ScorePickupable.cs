using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 1;

    public override void OnPickUp(Collider2D collision)
    {
        base.OnPickUp(collision);
        UI.instance.AddScore(scoreIncrease);
    }
}
