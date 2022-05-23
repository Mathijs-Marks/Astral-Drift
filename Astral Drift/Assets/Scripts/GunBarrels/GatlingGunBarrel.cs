using System.Collections;
using UnityEngine;

public class GatlingGunBarrel : BaseGunBarrel
{
    [SerializeField] private int bulletBurstAmount;
    [SerializeField] private float gatlingShootingRate;
    [SerializeField] private bool isMainTurret;

    private int currentBulletAmount = 0;
    private bool isShooting = false;
    private GameObject lookAtTarget;
    private Transform mainParentObject;

    private void Start()
    {
        if (shootOnStart)
            elapsedTime = shootingRate;

        if (isMainTurret)
        {
            lookAtTarget = GameObject.FindGameObjectWithTag("Player");
            mainParentObject = transform.parent.parent.parent;
        }
    }
    void FixedUpdate()
    {
        if (isMainTurret && !isShooting)
        {
            //Rotating
            Vector3 direction = lookAtTarget.transform.position - mainParentObject.position;
            Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.forward);
            rotation.x = mainParentObject.rotation.x;
            rotation.y = mainParentObject.rotation.y;
            mainParentObject.rotation = Quaternion.Lerp(mainParentObject.rotation, rotation, elapsedTime);
        }
        if (elapsedTime > shootingRate)
        {
            isShooting = true;
            if (elapsedTime > shootingRate + gatlingShootingRate) {
                Shoot();
                elapsedTime = shootingRate;

                currentBulletAmount++;
                if (currentBulletAmount >= bulletBurstAmount)
                {
                    elapsedTime = 0;
                    currentBulletAmount = 0;
                    isShooting = false;
                }
            }
        }
        elapsedTime += Time.deltaTime;
    }
}