using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private int speed;
    private int damage;

    // Set the bullet active with given values.
    public Bullet(Vector2 position, Vector2 direction, int speed, int damage, float lifespan)
    {
        SetActive(position, direction, speed, damage, lifespan);
    }

    // Set the bullet active with given values.
    public void SetActive(Vector2 position, Vector2 direction, int speed, int damage, float lifeSpan)
    {
        gameObject.SetActive(true);
        transform.position = position;

        this.direction = direction;
        this.direction.Normalize();

        this.speed = speed;
        this.damage = damage;

        StartCoroutine(Remove(lifeSpan));
    }

    // Reuse the same bullet.
    public void ResetBullet(Vector2 position, float lifeSpan)
    {
        gameObject.SetActive(true);
        transform.position = position;

        StartCoroutine(Remove(lifeSpan));
    }

    // Move.
    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Collide with player.
    private void OnTriggerEnter(Collider collision)
    {
        // TODO player collision (currently there is no player).
    }

    // Disable the bullet after x amount of time.
    public IEnumerator Remove(float timer)
    {
        yield return new WaitForSeconds(timer);

        // Disable bullet
        gameObject.SetActive(false);
    }
}
