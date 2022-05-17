using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGunBarrel : BaseGunBarrel
{
    void FixedUpdate()
    {
        if (elapsedTime > shootingRate)
        {
            Shoot();
            elapsedTime = 0;
        }
        elapsedTime += Time.deltaTime;
    }
}
