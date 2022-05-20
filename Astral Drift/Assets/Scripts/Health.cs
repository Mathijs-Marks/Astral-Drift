using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] protected int currentHitpoints;
    public int CurrentHitpoints { get { return currentHitpoints; } }

    public int maxHitpoints;
    private void Start()
    {
        currentHitpoints = maxHitpoints;
    }
    public virtual void TakeDamage(int damage)
    {
        currentHitpoints -= damage;
        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
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
    private void BulletCollision(int damage, GameObject bullet)
    {
        TakeDamage(damage);
        bullet.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out StandardBullet standardBullet)) //Bullet
        {
            BulletCollision(standardBullet.readDamage, collision.gameObject);
        } else if(collision.gameObject.TryGetComponent(out HomingBullet homingBullet))
        {
            BulletCollision(homingBullet.readDamage, collision.gameObject);
        } else if (collision.gameObject.TryGetComponent(out ScorePickupable scorePickupable))
        {
            //Do pickup code
        }
    }
}
