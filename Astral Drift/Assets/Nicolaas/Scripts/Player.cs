using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bullet;

    [SerializeField] private float playerSpeed;
    
    private Vector3 targetPosition;
    private Vector3 direction;

    [SerializeField] private float shootingRate;
    private float shootingTimer;

    [SerializeField] private Vector2 bulletDirection;
    [SerializeField] private int bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private int bulletLifespan;

    private void Start()
    {
        shootingTimer = 0;

        bullet.SetActive("Enemy", transform.position, bulletDirection, bulletSpeed, bulletDamage, bulletLifespan);
    }

    private void Update()
    {
        targetPosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        targetPosition.z = 0;
    }

    // Controls
    private void FixedUpdate()
    {
        // Moving
        direction = targetPosition - transform.position;

        // Check if the player is close enough to the desired position
        if (direction.magnitude > playerSpeed * Time.deltaTime)
        {
            direction.Normalize();
            transform.Translate(direction * playerSpeed * Time.deltaTime);
        }

        // Shooting
        shootingTimer += Time.deltaTime;

        if (shootingTimer > shootingRate)
        {
            shootingTimer = 0;

            bullet.ResetBullet(transform.position, 4);
        }
    }

    // Testing if you got hit
    public void GetHit(int damage)
    {
        Debug.Log("Player got hit. Reduce hitpoints. Hit for " + damage + " damage.");
    }
}
