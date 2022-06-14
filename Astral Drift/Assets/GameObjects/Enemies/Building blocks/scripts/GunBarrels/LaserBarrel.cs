using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBarrel : MonoBehaviour
{
  [SerializeField] private GameObject laserPointer;
  [SerializeField] private GameObject laser;

    private float totalTime;
    private float timeBeforeReset;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float AimingTime;
    [SerializeField] private float ShootingTime;

    private void Start()
    {
        totalTime = cooldownTime + AimingTime + ShootingTime;
        timeBeforeReset = AimingTime + ShootingTime;
    }
    private void LaserAimAndShoot()
    {
      if(timeBeforeReset <= AimingTime + ShootingTime)
        {
            laserPointer.SetActive(true);
        }
      else if(timeBeforeReset <= ShootingTime)
        {
            laserPointer.SetActive(false);
            laser.SetActive(true);
        }
      else if( timeBeforeReset <= 0)
        {
            laser.SetActive(false);
            timeBeforeReset = totalTime;
        }
        timeBeforeReset = timeBeforeReset - Time.fixedDeltaTime;
    }
    
}
