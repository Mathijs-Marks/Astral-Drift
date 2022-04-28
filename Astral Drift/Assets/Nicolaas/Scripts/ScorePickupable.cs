using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupable : Pickupable
{
    protected override void PickUp()
    {
        base.PickUp();

        UI.instance.AddScore(1);
    }
}
