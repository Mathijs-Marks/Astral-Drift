using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private GunBarrel[] weapons = new GunBarrel[2];

    [SerializeField] private float playerSpeed;
    [SerializeField] public int maxHitpoints;
    private int currentHitpoints;

    private Vector3 targetPosition;
    private Vector3 direction;

    private bool mousePointer;

    private void Start()
    {
        currentHitpoints = maxHitpoints;
        targetPosition = transform.position;
    }

    // Controls
    private void Update()
    {
        mousePointer = EventSystem.current.IsPointerOverGameObject();

        if (Input.GetMouseButton(0))
        {
            targetPosition = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0);
            targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
            targetPosition.z = 0;
        }
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

        GameOverHandler.instance.GameOver();
    }

    public void InscreaseShootingSpeed(float amount)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].IncreaseShootingSpeed(amount);
        }
    }
}
