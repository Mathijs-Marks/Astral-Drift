using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour
{
    protected int currentHitpoints;
    public int maxHitpoints;
    private void Start()
    {
        currentHitpoints = maxHitpoints;
    }
    //Enemy gets hit got hit
    public void TakeDamage(int damage)
    {
        currentHitpoints -= damage;

        if (currentHitpoints <= 0)
        {
            //TO DO: Enemy dies
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
    private void OnCollisionEnter(Collision collision)
    {
        TakeDamage(GetComponent<Bullet>().damage);
    }
}
