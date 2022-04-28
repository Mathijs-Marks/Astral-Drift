using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GunBarrel[] weapons = new GunBarrel[2];

    [SerializeField] private float playerSpeed;
    [SerializeField] public int maxHitpoints;
    private int currentHitpoints;

    private Vector3 targetPosition;
    private Vector3 direction;

    private void Start()
    {
        currentHitpoints = maxHitpoints;
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

    public void InscreaseShootingSpeed(float amount)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].IncreaseShootingSpeed(amount);
        }
    }
}
