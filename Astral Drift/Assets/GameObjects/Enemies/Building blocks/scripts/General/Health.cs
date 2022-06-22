
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Death))]
public class Health : MonoBehaviour
{
    private Death deathScript;

    protected int currentHitpoints;
    public int CurrentHitpoints { get { return currentHitpoints; } }

    public int maxHitpoints;

    [Tooltip("How much damage the player will receive. Leave blank in player health")]
    public int collisionDamageToPlayer = 10;

    protected virtual void Start()
    {
        deathScript = GetComponent<Death>();

        currentHitpoints = maxHitpoints;
    }

    public void OnDamage(int damage)
    {
        TakeDamage(damage);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHitpoints -= damage;
        if (currentHitpoints <= 0)
        {
            currentHitpoints = 0;
            OnHealthZero();
        }
    }
    public void Heal(int health)
    {
        currentHitpoints += health;

        if (currentHitpoints > maxHitpoints)
        {
            currentHitpoints = maxHitpoints;
        }
    }

    private void OnHealthZero()
    {
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
            //get/do pickup stuff
        }
    }
}
