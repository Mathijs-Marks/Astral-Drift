using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] protected int currentHitpoints;
    public int maxHitpoints;
    private void Start()
    {
        currentHitpoints = maxHitpoints;
    }
    public void TakeDamage(int damage)
    {
        currentHitpoints -= damage;
        Debug.Log(currentHitpoints);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out StandardBullet standardBullet))
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
