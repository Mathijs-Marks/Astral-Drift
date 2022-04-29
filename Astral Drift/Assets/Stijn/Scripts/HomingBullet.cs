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

    public HomingBullet(string collisionTag, Vector3 position, Vector3 direction, float speed, int damage, float lifespan) : base(collisionTag, position, direction, speed, damage, lifespan)
    {
        ActivateBullet(collisionTag, position, direction, speed, damage, lifespan);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(collisionTag);
        direction = transform.up;
        lerpTime = 0;
    }

    //Override fixedupdate to change the direction of the projectile
    protected override void FixedUpdate()
    {
        if (target.activeSelf && target != null)
        {
            directionToTarget = target.transform.position - this.transform.position;

            lookRotation = Quaternion.LookRotation(directionToTarget);

            if (lerpTime < 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, lerpTime);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                lerpTime += Time.deltaTime * rotatingSpeed;
            }
            else
            {
                lerpTime = 0;
            }
        }

        //Move the projectile forward
        base.FixedUpdate();
    }

}