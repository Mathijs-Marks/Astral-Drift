using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GatlingGunBarrel : BaseGunBarrel
{
    [SerializeField] private int bulletBurstAmount = 4; //Amount of bullets this barrel should shoot in one burst
    [SerializeField] private float gatlingShootingRate = 0.1f; //Time between amount bullet shot in one single burst

    private int currentBulletAmount = 0;

    protected override void Start()
    {
        base.Start();
    }
    void FixedUpdate()
    {
        //Time in between bursts
        if (elapsedTime > shootingRate)
        {
            //Time in between bullet shots
            if (elapsedTime > shootingRate + gatlingShootingRate) {

                Shoot();
                elapsedTime = shootingRate;

                currentBulletAmount++;
                //When all bullets have been fired, reset sequence
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