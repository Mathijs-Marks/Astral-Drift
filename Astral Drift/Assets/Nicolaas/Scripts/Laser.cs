using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer laserRenderer;

    private string collisionTag;

    private Vector3 direction = new Vector3(0, 0, 1);
    private int damage;
    [SerializeField] private float laserLength = 20;

    private IEnumerator removeCoroutine;

    // Set the laser active with given values.
    public Laser(string collisionTag, Vector3 originPosition, Vector3 direction, float laserLength, int damage, float lifespan, float laserWidth)
    {
        Instantiate(collisionTag, originPosition, direction, laserLength, damage, lifespan, laserWidth);
    }

    // Check if the laser hits
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.rotation * direction, laserLength);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            CollideWithTag(hit.collider);
        }
    }

    // Set the laser active with given values.
    public void Instantiate(string collisionTag, Vector3 originPosition, Vector3 direction, float laserLength, int damage, float lifespan, float laserWidth)
    {
        laserRenderer.SetPosition(1, direction * laserLength);
        laserRenderer.startWidth = laserWidth;

        gameObject.SetActive(true);
        transform.position = originPosition;

        this.collisionTag = collisionTag;
        this.direction = direction;
        this.direction.Normalize();

        this.laserLength = laserLength;
        this.damage = damage;

        StartRemoveTimer(lifespan);
    }

    // Reuse the same laser.
    public void ResetLaser(Vector3 position, float lifespan)
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

    // Disable the laser after x amount of time.
    public IEnumerator Remove(float timer)
    {
        yield return new WaitForSeconds(timer);

        // Disable laser
        gameObject.SetActive(false);
    }

    // Collide with player.
    private void CollideWithTag(Collider2D collision)
    {
        if (collisionTag == "Player")
        {
            collision.gameObject.GetComponent<Player>().GetHit(damage);
        }
        if (collisionTag == "Enemy")
        {
            collision.gameObject.GetComponent<StationaryEnemy>().GetHit(damage);
        }
    }
}
