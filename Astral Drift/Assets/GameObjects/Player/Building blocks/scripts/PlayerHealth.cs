using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    protected UnityEvent playerOnHitEvent;
    public UnityEvent PlayerOnHitEvent
    {
        get { return playerOnHitEvent; }
        set { playerOnHitEvent = value; }
    }
    private void Awake()
    {
        PlayerOnHitEvent = new UnityEvent();
        GlobalReferenceManager.PlayerHealthScript = this;
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        playerOnHitEvent.Invoke();
    }
}
