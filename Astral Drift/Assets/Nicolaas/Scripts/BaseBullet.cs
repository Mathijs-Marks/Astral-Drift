using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    public int readDamage { get { return damage; } }
    
    protected virtual void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Disable the bullet after x amount of time.
    public void Remove()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) //Bullet
        {
        }
    }
}
