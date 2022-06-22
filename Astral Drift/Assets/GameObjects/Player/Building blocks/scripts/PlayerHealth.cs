using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    protected UnityEvent playerOnHitEvent;


    [SerializeField] private int collisionDamageToEnemy = 50;
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

    public override void DoCollision(Collider2D collision)
    {
        base.DoCollision(collision);

        //Enemy collision with player will damage player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Get the enemy's health component and see how much damage it should receive and apply
            collision.gameObject.TryGetComponent(out Health enemyHealth);
            enemyHealth.OnDamage(collisionDamageToEnemy);
            OnDamage(enemyHealth.collisionDamageToPlayer);
        }
    }
}
