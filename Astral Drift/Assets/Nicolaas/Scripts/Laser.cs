using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer laserRenderer;

    private string collisionTag;

    private Vector3 direction = new Vector3(0, 0, 1);
    private int damage;
    private bool isActive;
    [SerializeField] private float laserLength = 20;

    private IEnumerator removeCoroutine;

    // Set the laser active with given values.
    public Laser(string collisionTag, Vector3 originPosition, Vector3 direction, int damage, float lifespan)
    {
        Instantiate(collisionTag, originPosition, direction, damage, lifespan);
    }

    // Move.
    private void FixedUpdate()
    {
        direction = new Vector3(0, 0, 1);
        laserRenderer.SetPosition(1, direction * laserLength);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.rotation * direction, laserLength);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            Debug.Log("hellow world");
        }
    }

    // Set the laser active with given values.
    public void Instantiate(string collisionTag, Vector3 originPosition, Vector3 direction, int damage, float lifespan)
    {
        gameObject.SetActive(true);
        transform.position = originPosition;

        this.collisionTag = collisionTag;
        this.direction = direction;
        this.direction.Normalize();

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
