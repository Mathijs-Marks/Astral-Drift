using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected float speed;
    protected int damage;
    public int readDamage { get { return damage; } }

    //Makes a bullet with provided data
    public void InitializeBullet(int tempDamage, float tempSpeed)
    {
        damage = tempDamage;
        speed = tempSpeed;
    }

    // Move towards the direction the bullet is rotated towards
    protected virtual void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Disable the bullet after x amount of time.
    public void Remove()
    {
        gameObject.SetActive(false);
    }
}
