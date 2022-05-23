using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public override void TakeDamage(int damage)
    {
        currentHitpoints -= damage;

        // If hit points equals 0, invoke death.
        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            GlobalReferenceManager.GameOverMenu.DeathEvent.Invoke();
        }
    }
}
