using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a testing script that can be removed later.
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    private float timer = 2;

    // Shoot a bullet.
    private void Start()
    {
        bullet.ActivateBullet("Player", transform.position, new Vector2(0, -1), 2, 1, 3);
    }

    // After x amount of time, shoot a bullet.
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        bullet.speed += Time.deltaTime;

        if (timer < 0)
        {
            timer = 4;

            bullet.ResetBullet(transform.position, 3);
            bullet.speed = 2;
        }
    }
}
