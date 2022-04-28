using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bullet;

    [SerializeField] private float playerSpeed;
    [SerializeField] public int maxHitpoints;
    private int currentHitpoints;

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
        currentHitpoints = maxHitpoints;

        shootingTimer = 0;

        bullet.ActivateBullet("Enemy", transform.position, bulletDirection, bulletSpeed, bulletDamage, bulletLifespan);
    }

    // Controls
    private void Update()
    {
        targetPosition = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0);
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        targetPosition.z = 0;
    }

    // Moving and shooting
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
        else
        {
            transform.position = targetPosition;
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
        currentHitpoints -= damage;
        UI.instance.UpdateHitpoints(currentHitpoints);

        if (currentHitpoints <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        gameObject.SetActive(false);

        // TODO: Game over code
    }
}
