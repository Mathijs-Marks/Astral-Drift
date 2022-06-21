using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIPlayer : HealthBarUI
{
    protected override void Start()
    {
        healthScript = GlobalReferenceManager.PlayerHealthScript;
        base.Start();
    }

    protected override void UpdateHealthBar()
    {
        base.UpdateHealthBar();
        mask.transform.localPosition = new Vector3(0, -amount, 0);
    }
}
