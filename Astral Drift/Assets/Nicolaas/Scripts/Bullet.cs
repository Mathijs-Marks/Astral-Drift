using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected string collisionTag;

    protected Vector3 direction;
    [HideInInspector] public float speed;
    public int damage;

    private IEnumerator removeCoroutine;

    // Set the bullet active with given values.
    public Bullet(string collisionTag, Vector3 position, Vector3 direction, float speed, int damage, float lifespan)
    {
        ActivateBullet(collisionTag, position, direction, speed, damage, lifespan);
    }

    // Move.
    protected virtual void FixedUpdate()
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
}
