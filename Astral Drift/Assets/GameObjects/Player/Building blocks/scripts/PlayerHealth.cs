using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    protected UnityEvent playerOnHitEvent;
    protected UnityEvent playerOnHealEvent;

    [SerializeField] private int collisionDamageToEnemy = 50;

    [HideInInspector] public bool canSpawnHealthPickups;
    public UnityEvent PlayerOnHitEvent
    {
        get { return playerOnHitEvent; }
        set { playerOnHitEvent = value; }
    }
    public UnityEvent PlayerOnHealEvent
    {
        get { return playerOnHealEvent; }
        set { playerOnHealEvent = value; }
    }
    private void Awake()
    {
        PlayerOnHitEvent = new UnityEvent();
        PlayerOnHealEvent = new UnityEvent();
        GlobalReferenceManager.PlayerHealthScript = this;
    }
    public override void Heal(int health)
    {
        base.Heal(health);

        playerOnHealEvent.Invoke();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (!canSpawnHealthPickups)
            if (GlobalReferenceManager.PlayerHealthScript.currentHitpoints < GlobalReferenceManager.PlayerHealthScript.maxHitpoints / 2)
                canSpawnHealthPickups = true;

        playerOnHitEvent.Invoke();
    }

    public override void DoCollision(Collider2D collision)
    {
        base.DoCollision(collision);

        //Enemy collision with player will damage player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Get the enemy's health component and see how much damage it should receive and apply
            collision.gameObject.TryGetComponent(out Health enemyHealth);
            if(enemyHealth.maxHitpoints <= collisionDamageToEnemy)
                enemyHealth.OnDamage(collisionDamageToEnemy);
            else
                enemyHealth.OnDamage(enemyHealth.maxHitpoints / 2);

            OnDamage(enemyHealth.collisionDamageToPlayer);
        }
    }
}
