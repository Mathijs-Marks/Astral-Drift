using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : BaseBullet
{
    private GameObject target;
    private Vector3 directionToTarget;

    [SerializeField] private float rotatingLerpSpeedMultiplier = 1;
    private Quaternion lookRotation;
    private float lerpTime;

    // value that increments from 0 to 0.5, after that the bullets start homing towards the player.
    private float currentHomingStartTimer;
    //For this duration the bullet will travel forwards, afterwards it will start homing
    [SerializeField] private float homingStartTime = 0.5f;
    //The distance at which the projectile will stop homing
    [SerializeField] private float stopHomingDistance = 1.8f;
    private bool shouldBeHoming;

    private float currentFollowTime;
    [SerializeField] private float maxFollowTime = 2f; //Max time how long the bullet should be following the player

    // Start is called before the first frame update
    void Start()
    {
        target = GlobalReferenceManager.PlayerPosition.gameObject;
        lerpTime = 0;
        shouldBeHoming = true;
    }

    //fixedupdate to change the direction of the projectile
    protected void FixedUpdate()
    {
        if (currentHomingStartTimer < homingStartTime)
        {
            lookRotation.x = 0;
            lookRotation.y = 0;
            currentHomingStartTimer += 0.01f;
        }
        else
        {
            RotateToTarget();
        }
        Move();
    }

    //Rotate the projectile towards the target
    private void RotateToTarget()
    {
        if (target != null)
        {
            if (target.activeSelf)
            {
                directionToTarget = target.transform.position - this.transform.position;

                lookRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);
                lookRotation.x = 0;
                lookRotation.y = 0;

                //When following for more than maxfollowtime
                if (currentFollowTime < maxFollowTime && shouldBeHoming)
                {
                    //Stop rotating once the missile has been close once
                    if (directionToTarget.magnitude >= stopHomingDistance)
                    {
                        currentFollowTime += 0.01f;

                        //Lerp from current rotation to lookrotation
                        if (lerpTime < 1)
                        {
                            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lerpTime);
                            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                            lerpTime += Time.deltaTime * rotatingLerpSpeedMultiplier;
                        }
                        else
                        {
                            lerpTime = 0;
                        }

                    }
                    else
                    {
                        // stop following
                        shouldBeHoming = false;
                    }
                }
                else
                {
                    shouldBeHoming = false;
                }
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z));
            }
        }
    }

    //Get the angle between two vectors. This function also gets negative angles
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}