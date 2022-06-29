using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIEnemy : HealthBarUI
{
    [SerializeField] private float enabledTime = 2;
    private float timer;

    protected override void Start()
    {
        timer = 0;

        healthScript.OnHitEvent.AddListener(EnableSelf);

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
                DisableSelf();
            }
        }
    }

    protected override void UpdateHealthBar()
    {
        base.UpdateHealthBar();

        if (healthScript.CurrentHitpoints <= 0)
        {
            gameObject.SetActive(false);
        }

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
