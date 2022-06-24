using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIPlayer : HealthBarUI
{
    private float amount;

    protected override void Start()
    {
        healthScript = GlobalReferenceManager.PlayerHealthScript;
        base.Start();
    }

    protected override void UpdateHealthBar()
    {
        base.UpdateHealthBar();

        amount = (healthScript.maxHitpoints - healthScript.CurrentHitpoints) * spriteSize / healthScript.maxHitpoints;

        // TODO: This code may need to be reworked in the future if there is ever a reason to use multiple objects with this script in the canvas.
        fullBar.transform.localPosition = new Vector3(0, amount, 0);
        mask.transform.localPosition = new Vector3(0, -amount, 0);
    }
}
