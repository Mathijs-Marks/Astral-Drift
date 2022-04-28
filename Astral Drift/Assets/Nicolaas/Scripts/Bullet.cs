using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private string collisionTag;

    private Vector3 direction;
    [HideInInspector] public float speed;
    private int damage;

    private IEnumerator removeCoroutine;

    // Set the bullet active with given values.
    public Bullet(string collisionTag, Vector3 position, Vector3 direction, float speed, int damage, float lifespan)
    {
        ActivateBullet(collisionTag, position, direction, speed, damage, lifespan);
    }

    // Move.
    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Set the bullet active with given values.
    public void ActivateBullet(string collisionTag, Vector3 position, Vector3 direction, float speed, int damage, float lifespan)
    {
        gameObject.SetActive(true);
        transform.position = position;

        this.collisionTag = collisionTag;
        this.direction = direction;
        this.direction.Normalize();

        this.speed = speed;
        this.damage = damage;

        StartRemoveTimer(lifespan);
    }

    // Reuse the same bullet.
    public void ResetBullet(Vector3 position, float lifespan)
    {
        gameObject.SetActive(true);
        transform.position = position;

        StartRemoveTimer(lifespan);
    }

    private void StartRemoveTimer(float lifespan)
    {
        if (removeCoroutine != null)
        {
            StopCoroutine(removeCoroutine);
        }
        removeCoroutine = Remove(lifespan);

        StartCoroutine(removeCoroutine);
    }

    // Disable the bullet after x amount of time.
    public IEnumerator Remove(float timer)
    {
        yield return new WaitForSeconds(timer);

        // Disable bullet
        gameObject.SetActive(false);
    }

    // Collide with player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(collisionTag))
        {
            if (collisionTag == "Player")
            {
                collision.gameObject.GetComponent<Player>().GetHit(damage);

                StopCoroutine(removeCoroutine);
            }
            gameObject.SetActive(false);
        }
        if (collision.CompareTag(collisionTag))
        {
            if (collisionTag == "Enemy")
            {
                collision.gameObject.GetComponent<StationaryEnemy>().GetHit(damage);

                StopCoroutine(removeCoroutine);
            }
            gameObject.SetActive(false);
        }
    }
}
