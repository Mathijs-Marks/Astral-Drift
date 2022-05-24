using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    private void Awake()
    {
        GlobalReferenceManager.PlayerHealthScript = this;
    }

    public override void TakeDamage(int damage)
    {
        currentHitpoints -= damage;
        GlobalReferenceManager.UIMenu.UpdateDamage.Invoke();

        // If hit points equals 0, invoke death.
        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            GlobalReferenceManager.GameOverMenu.ScreenEvent.Invoke(GlobalReferenceManager.GameOverMenu.gameOverScreen);
        }
    }
}
