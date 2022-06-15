using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GatlingGunBarrel : BaseGunBarrel
{
    [SerializeField] private int bulletBurstAmount = 4;
    [SerializeField] private float gatlingShootingRate = 0.1f;

    private int currentBulletAmount = 0;

    [Header("Leave empty if this enemy needs to rotate while shooting. Otherwise, reference \"InvertIsRotating\" from \"RotateToPlayer\"")]
    [SerializeField] private UnityEvent isShootingEvent;
    [SerializeField] private UnityEvent isNotShootingEvent;

    protected override void Start()
    {
        base.Start();
        if (shootOnStart)
            elapsedTime = shootingRate;
    }
    void FixedUpdate()
    {
        if (elapsedTime > shootingRate)
        {
            if (elapsedTime > shootingRate + gatlingShootingRate) {
                if (currentBulletAmount == 0)
                {
                    isShootingEvent.Invoke();
                }
                
                Shoot();
                elapsedTime = shootingRate;

                currentBulletAmount++;
                if (currentBulletAmount >= bulletBurstAmount)
                {
                    elapsedTime = 0;
                    currentBulletAmount = 0;

                    isNotShootingEvent.Invoke();
                }
            }
        }
        elapsedTime += Time.deltaTime;
    }
}