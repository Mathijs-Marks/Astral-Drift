using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] protected Health healthScript;

    [SerializeField] protected GameObject fullBar, mask;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] private float spriteSize = 686;

    [Tooltip("False if this is in the canvas. For now, This will be used a lot outside of it and needs to be true.)")]

    private int percentage;
    
    protected float amount;

    protected virtual void Start()
    {
        healthScript.OnHitEvent.AddListener(UpdateHealthBar);
    }

    protected virtual void UpdateHealthBar()
    {
        percentage = healthScript.CurrentHitpoints;
        if (percentage <= 0)
        {
            gameObject.SetActive(false);
        }

        amount = (healthScript.maxHitpoints - percentage) * spriteSize / healthScript.maxHitpoints;

        fullBar.transform.localPosition = new Vector3(0, amount, 0);
    }
}
