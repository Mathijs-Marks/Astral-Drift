using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private GameObject fullBar, mask;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] private float spriteSize = 686;

    private int percentage;
    
    private float amount;
    private void Start()
    {
        GlobalReferenceManager.PlayerHealthScript.OnHitEvent.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        percentage = GlobalReferenceManager.PlayerHealthScript.CurrentHitpoints;

        amount = (100 - percentage) * spriteSize / 100;

        fullBar.transform.localPosition = new Vector3(0, amount, 0);
        mask.transform.localPosition = new Vector3(0, -amount, 0);
    }
}
