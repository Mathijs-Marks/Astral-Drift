using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [Header("You don't need to initialize healthScript if this script is HealthBarUIPlayer")]
    [SerializeField] protected Health healthScript;
    [SerializeField] protected GameObject fullBar, mask;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] protected float spriteSize = 686; // In the canvas, this value is equal to the width or height of the mask sprite. Take the bigger number

    protected virtual void Start()
    {
        // Health script will update the health bar whenever they're hit.
        healthScript.OnHitEvent.AddListener(UpdateHealthBar);
    }

    protected virtual void UpdateHealthBar()
    {
        // This function is used for inheritance.
        // TODO: Health Bar UI Enemy likely needs to be reworked to work in the canvas.
        // When it does, both Health Bar UI Enemy and Health Bar UI Player can use this function for updating health.
    }
}
