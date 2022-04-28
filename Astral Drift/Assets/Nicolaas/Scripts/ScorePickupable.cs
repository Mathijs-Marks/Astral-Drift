using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 1;

    protected override void PickUp()
    {
        base.PickUp();

        UI.instance.AddScore(scoreIncrease);
    }
}
