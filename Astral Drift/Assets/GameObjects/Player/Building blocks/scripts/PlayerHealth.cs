using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    protected UnityEvent playerOnHealEvent;
    [SerializeField] private int collisionDamageToEnemy = 50;

    [HideInInspector] public bool canSpawnHealthPickups;
    public UnityEvent PlayerOnHealEvent
    {
        get { return playerOnHealEvent; }
        set { playerOnHealEvent = value; }
    }
    protected override void Awake()
        {
        base.Awake();
        PlayerOnHealEvent = new UnityEvent();
        GlobalReferenceManager.PlayerHealthScript = this;
    }
    public override void Heal(int health)
    {
        base.Heal(health);

        playerOnHealEvent.Invoke();
    }
    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);

        if (!canSpawnHealthPickups)
            if (GlobalReferenceManager.PlayerHealthScript.currentHitpoints < GlobalReferenceManager.PlayerHealthScript.maxHitpoints / 2)
                canSpawnHealthPickups = true;
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

            GlobalReferenceManager.AudioManagerRef.PlaySound("EnemyCollision");
        }
    }
}
