using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickupable : MonoBehaviour
{
    [SerializeField] protected GameObject particlePrefab;
    [SerializeField] private float maxDistance = 3;
    [SerializeField] protected float particleDestroyTimer = 1;
    [SerializeField] protected string pickUpAudioName;
    private Rigidbody2D rb;
    private Vector2 randomDirection;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomDirection.x = Random.Range(-maxDistance, maxDistance);
        randomDirection.y = Random.Range(-maxDistance, maxDistance);
        rb.AddForce(randomDirection, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Make this layer based
        if (collision.tag == "Player")
        {
            OnPickUp(collision);
        }
    }

    // Expand on pick up by inheriting and overriding this function (Don't forget base.OnPuckUp())
    public virtual void OnPickUp(Collider2D collision)
    {
        gameObject.SetActive(false);

        if (GlobalReferenceManager.AudioManagerRef != null)
            GlobalReferenceManager.AudioManagerRef.PlaySound(pickUpAudioName);

        if (particlePrefab != null)
        {
            GameObject newPickup = Instantiate(particlePrefab, transform.position, transform.rotation);
            Destroy(newPickup, particleDestroyTimer);
        }
    }
}
