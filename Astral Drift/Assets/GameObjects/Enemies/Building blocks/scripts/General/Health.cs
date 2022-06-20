
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D), typeof(Death))]
public class Health : MonoBehaviour
{
    private UnityEvent onHitEvent;

    public UnityEvent OnHitEvent
    {
        get { return onHitEvent; }
        set { onHitEvent = value; }
    }

    [SerializeField] private UnityEvent flashOnHit;

    private Death deathScript;

    protected int currentHitpoints;
    public int CurrentHitpoints { get { return currentHitpoints; } }

    public int maxHitpoints;
    protected virtual void Start()
    {
        OnHitEvent = new UnityEvent();

        deathScript = GetComponent<Death>();

        currentHitpoints = maxHitpoints;
    }

    public void OnDamage(int damage)
    {
        TakeDamage(damage);
        flashOnHit.Invoke();
        OnHitEvent.Invoke();
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

    protected void BulletCollision(int damage, GameObject bullet)
    {
        OnDamage(damage);
        bullet.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoCollision(collision);
    }

    protected virtual void DoCollision(Collider2D collision)
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
