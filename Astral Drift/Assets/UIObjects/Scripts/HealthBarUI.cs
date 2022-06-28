using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [Header("You don't need to initialize healthScript if this script is HealthBarUIPlayer")]
    [SerializeField] protected Health healthScript;
    [SerializeField] protected GameObject fullBar, mask;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] protected float spriteSize = 686;

    protected virtual void Start()
    {
        healthScript.OnHitEvent.AddListener(UpdateHealthBar);
    }

    protected virtual void UpdateHealthBar()
    {
        // This function is used for inheritance.
    }
}
