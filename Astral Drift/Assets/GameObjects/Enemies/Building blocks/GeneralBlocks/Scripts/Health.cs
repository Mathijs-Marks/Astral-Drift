
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D), typeof(Death))]
public class Health : MonoBehaviour
{
    private UnityEvent onHitEvent; // On hit events with bullets

    public UnityEvent OnHitEvent
    {
        get { return onHitEvent; }
        set { onHitEvent = value; }
    }

    public UnityEvent flashOnHit; // Flash effect when damaged. This value needs to get the Flash function from the flash on hit script

    private Death deathScript;

    protected bool isDead;
    protected int currentHitpoints;
    public int CurrentHitpoints { get { return currentHitpoints; } }

    public int maxHitpoints;

    [Tooltip("How much damage the player will receive. Leave blank in player health")]
    public int collisionDamageToPlayer = 15;

    protected virtual void Awake()
    {
        OnHitEvent = new UnityEvent();

        deathScript = GetComponent<Death>();

        currentHitpoints = maxHitpoints;
    }

    public virtual void OnDamage(int damage)
    {
        // When damaged, apply int damage value, apply a flash effect and call more on hit events (Update UI for example)
        TakeDamage(damage);
        flashOnHit.Invoke();
        OnHitEvent.Invoke();
    }
    public virtual void TakeDamage(int damage)
    {
        // Substract health
        currentHitpoints -= damage;

        // When health is zero, call on health zero
        if (currentHitpoints <= 0)
        {
            if (!isDead)
            {
                currentHitpoints = 0;
                isDead = true;
                OnHealthZero();
            }
        }
    }
    public virtual void Heal(int health)
    {
        currentHitpoints += health;

        if (currentHitpoints > maxHitpoints)
        {
            currentHitpoints = maxHitpoints;
        }
    }

    private void OnHealthZero()
    {
        // Invoke death event from a death script attached to the player
        deathScript.DeathEvent.Invoke();
    }
    protected void LaserCollision(int damage)
    {
        OnDamage(damage);
    }
    protected void BulletCollision(int damage, GameObject bullet)
    {
        OnDamage(damage);
        bullet.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoCollision(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            if (collision.gameObject.TryGetComponent(out Laser laser))
                LaserCollision(laser.readDamage);
        }
    }
    public virtual void DoCollision(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) //Bullet
        {
            if (collision.gameObject.TryGetComponent(out StandardBullet standardBullet))
                BulletCollision(standardBullet.readDamage, collision.gameObject);
            else if (collision.gameObject.TryGetComponent(out HomingBullet homingBullet))
                BulletCollision(homingBullet.readDamage, collision.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            if (collision.gameObject.TryGetComponent(out StandardBullet standardBullet))
                BulletCollision(standardBullet.readDamage, collision.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (collision.gameObject.TryGetComponent(out Pickupable pickupable))
                pickupable.OnPickUp(collision);
        }
    }
}
