using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBarrel : MonoBehaviour
{
  [SerializeField] private GameObject laserPointer;
  [SerializeField] private GameObject laser;

    private float totalTime;
    private float timeBeforeReset;
    private float shootTimer;

    private int state = 0;

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
    private void FixedUpdate()
    {
        shootTimer -= Time.fixedDeltaTime;
        if (shootTimer < 0)
        {
            ChangeState();
        }
    }
    void ChangeState()
    {
        if (state == 2)
        {
            state = 0;
        }
        else
        {
        state++;
        }

        switch(state){
            case 0:
                laserPointer.SetActive(true);
                shootTimer = AimingTime;
                break;
                    case 1:
                laserPointer.SetActive(false);
                laser.SetActive(true);
                shootTimer = ShootingTime;
                break;
            case 2:
                laser.SetActive(false);
                shootTimer = cooldownTime;
                break;
        }
    }
}
