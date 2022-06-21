using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health healthScript;

    [SerializeField] private GameObject fullBar, mask;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] private float spriteSize = 686;

    [Tooltip("False if this is in the canvas. For now, This will be used a lot outside of it and needs to be true.)")]
    [SerializeField] private bool outsideCanvas = true;
    [SerializeField] private bool disableWhenUndamaged = true;

    private int percentage;
    
    private float amount;

    [SerializeField] private float enabledTime = 2;
    private float timer;

    private void Start()
    {
        timer = 0;

        if (disableWhenUndamaged)
            gameObject.SetActive(false);

        healthScript.OnHitEvent.AddListener(UpdateHealthBar);
        healthScript.OnHitEvent.AddListener(EnableSelf);
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

    private void UpdateHealthBar()
    {
        percentage = healthScript.CurrentHitpoints;
        if (percentage <= 0)
        {
            gameObject.SetActive(false);
        }

        amount = (healthScript.maxHitpoints - percentage) * spriteSize / healthScript.maxHitpoints;

        fullBar.transform.localPosition = new Vector3(0, amount, 0);

        if (!outsideCanvas)
            mask.transform.localPosition = new Vector3(0, -amount, 0);
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
