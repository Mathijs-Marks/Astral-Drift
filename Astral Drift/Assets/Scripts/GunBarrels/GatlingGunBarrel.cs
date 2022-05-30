using System.Collections;
using UnityEngine;

public class GatlingGunBarrel : BaseGunBarrel
{
    [SerializeField] private int bulletBurstAmount = 4;
    [SerializeField] private float gatlingShootingRate = 0.1f;

    private int currentBulletAmount = 0;

    private void Start()
    {
        if (shootOnStart)
            elapsedTime = shootingRate;
    }
    void FixedUpdate()
    {
        if (elapsedTime > shootingRate)
        {
            if (elapsedTime > shootingRate + gatlingShootingRate) {
                Shoot();
                elapsedTime = shootingRate;

                currentBulletAmount++;
                if (currentBulletAmount >= bulletBurstAmount)
                {
                    elapsedTime = 0;
                    currentBulletAmount = 0;
                }
            }
        }
        elapsedTime += Time.deltaTime;
    }
}