using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopRotationDuringFire : RotateToPlayer
{
    private int barrelsShootingAmount;

    public void Shoot()
    {
        if (barrelsShootingAmount == 0)
        {
            SetIsRotating(false);
        }

        barrelsShootingAmount++;
    }

    public void StopShooting()
    {
        barrelsShootingAmount--;

        if (barrelsShootingAmount == 0)
        {
            SetIsRotating(true);
        }
    }
}
