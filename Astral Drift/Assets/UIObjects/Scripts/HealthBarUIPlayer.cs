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
}
