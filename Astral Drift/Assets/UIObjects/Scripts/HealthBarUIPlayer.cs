using UnityEngine;

public class HealthBarUIPlayer : HealthBarUI
{
    private float amount;

    protected override void Start()
    {
        healthScript = GlobalReferenceManager.PlayerHealthScript;
        GlobalReferenceManager.PlayerHealthScript.PlayerOnHealEvent.AddListener(UpdateHealthBar);
        base.Start();
    }

    protected override void UpdateHealthBar()
    {
        base.UpdateHealthBar();

        amount = (healthScript.maxHitpoints - healthScript.CurrentHitpoints) * spriteSize / healthScript.maxHitpoints;

        // TODO: This code needs to be reworked in the future if there is ever a reason to use multiple objects with this script in the canvas.
        // There is a bug whenever a mask is positioned over another health bar, it starts masking the health bar it isn't attached to.
        // Scaling with masking likely needs to be used to fix this issue
        fullBar.transform.localPosition = new Vector3(0, amount, 0);
        mask.transform.localPosition = new Vector3(0, -amount, 0);
    }
}
