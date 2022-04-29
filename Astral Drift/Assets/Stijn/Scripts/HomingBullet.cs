using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    [SerializeField]private GameObject target;
    private Vector3 directionToTarget;

    [SerializeField] private float rotatingSpeed = 1;
    private Quaternion lookRotation;
    private float lerpTime;

    private Rigidbody2D rb;
    [SerializeField]private bool useRigidbody;
    private float currentHomingStartTimer;
    private float homingStartTime;
    private float stopHomingDistance;
    private bool shouldBeHoming = true;

    public HomingBullet(string collisionTag, Vector3 position, Vector3 direction, float speed, int damage, float lifespan) : base(collisionTag, position, direction, speed, damage, lifespan)
    {
        ActivateBullet(collisionTag, position, direction, speed, damage, lifespan);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag(collisionTag);
        direction = transform.up;
        homingStartTime = 0.5f;
        stopHomingDistance = 0.01f;
        lerpTime = 0;
    }

    //Override fixedupdate to change the direction of the projectile
    protected override void FixedUpdate()
    {
        if (useRigidbody) 
        {
            HomingRigidbody();
        }
        else
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

    }

    //Rotate the projectile towards the target
    private void RotateToTarget()
    {
        if (target != null)
        {
            if (target.activeSelf)
            {
                directionToTarget = target.transform.position - this.transform.position;

                lookRotation = Quaternion.LookRotation(directionToTarget);
                //Debug.Log(directionToTarget.magnitude);
                

                if (directionToTarget.magnitude >= stopHomingDistance)
                {
                        //Lerp from current rotation to lookrotation
                        if (lerpTime < 1)
                        {
                            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lerpTime);
                            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
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
                    //Debug.Log("STOP HOMING");
                }
            }
        }
    }

    private void HomingRigidbody()
    {
        Vector2 newdirection = (Vector2)target.transform.position - rb.position;

        newdirection.Normalize();

        float rotateAmount = Vector3.Cross(newdirection, -transform.up).z;

        rb.angularVelocity = -rotateAmount * 200;
            
        rb.velocity = -transform.up * 1;
    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

}