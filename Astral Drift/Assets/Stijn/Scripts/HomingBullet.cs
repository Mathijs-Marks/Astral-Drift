using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    private GameObject target;
    private Vector3 directionToTarget;

    [SerializeField] private float rotatingSpeed = 1;
    private Quaternion lookRotation;
    private float lerpTime;

    private float currentHomingStartTimer;
    private float homingStartTime;
    private float stopHomingDistance;
    private bool shouldBeHoming;

    public HomingBullet(string collisionTag, Vector3 position, Vector3 direction, float speed, int damage, float lifespan) : base(collisionTag, position, direction, speed, damage, lifespan)
    {
        ActivateBullet(collisionTag, position, direction, speed, damage, lifespan);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(collisionTag);
        homingStartTime = 0.5f;
        lerpTime = 0;
        shouldBeHoming = true;

        //The distance at which the projectile will stop homing
        stopHomingDistance = 1f;

    }

    //Override fixedupdate to change the direction of the projectile
    protected override void FixedUpdate()
    {
        if (currentHomingStartTimer < homingStartTime)
        {
            currentHomingStartTimer += 0.01f;
        }
        else
        {
            RotateToTarget();
        }

        //Move the projectile forward
        base.FixedUpdate();
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

                //Stop rotating once the missile has been close once
                if (directionToTarget.magnitude >= stopHomingDistance && shouldBeHoming)
                {
                    //Lerp from current rotation to lookrotation
                    if (lerpTime < 1)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lerpTime);
                        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // The z position is being reset here.
                        lerpTime += Time.deltaTime * rotatingSpeed;
                    }
                    else
                    {
                         lerpTime = 0;
                    }
                }
                else
                {
                    shouldBeHoming = false;
                }
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