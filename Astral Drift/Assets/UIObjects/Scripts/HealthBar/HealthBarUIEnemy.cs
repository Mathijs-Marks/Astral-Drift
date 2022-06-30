using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIEnemy : HealthBarUI
{
    [SerializeField] private float enabledTime = 2; // Time this object will be shown to the player
    private float timer;

    protected override void Start()
    {
        timer = 0;

        // Health script now also shows this object
        healthScript.OnHitEvent.AddListener(EnableSelf);

        // All enemy health bars start invisible
        gameObject.SetActive(false);

        base.Start();

    }

    private void FixedUpdate()
    {
        TimerTickDown();
    }

    private void TimerTickDown()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // After enable time has expired, disable this object again
                DisableSelf();
            }
        }
    }

    protected override void UpdateHealthBar()
    {
        base.UpdateHealthBar();

        // If health is zero, don't show the health bar
        if (healthScript.CurrentHitpoints <= 0)
        {
            gameObject.SetActive(false);
        }

        // Scale down mask
        mask.transform.localScale = new Vector3((float)healthScript.CurrentHitpoints / healthScript.maxHitpoints, mask.transform.localScale.y, mask.transform.localScale.z);
    }

    private void EnableSelf()
    {
        gameObject.SetActive(true);
        timer = enabledTime;
    }

    private void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
