using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class healthBarUI : MonoBehaviour
{
    [SerializeField] private Health healthScript;

    [SerializeField] private GameObject fullBar, mask;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] private float spriteSize = 686;

    private int percentage;
    
    private float amount;
    
    private void Start()
    {
        healthScript.OnHitEvent.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        percentage = healthScript.CurrentHitpoints;

        amount = (100 - percentage) * spriteSize / 100;

        fullBar.transform.localPosition = new Vector3(0, amount, 0);
        mask.transform.localPosition = new Vector3(0, -amount, 0);
    }
}
