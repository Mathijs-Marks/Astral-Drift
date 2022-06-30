using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickupable : MonoBehaviour
{
    [SerializeField] protected GameObject particlePrefab; //Particle prefab to spawn
    [SerializeField] private float maxDistance = 3; //Max amount to move after spawning
    [SerializeField] protected float particleDestroyTimer = 1;
    [SerializeField] protected string pickUpAudioName;
    private Rigidbody2D rb;
    private Vector2 randomDirection; //Random direction where pickup shoots off in
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Random direction to throw pickup to
        randomDirection.x = Random.Range(-maxDistance, maxDistance);
        randomDirection.y = Random.Range(-maxDistance, maxDistance);
        rb.AddForce(randomDirection, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnPickUp(collision);
        }
    }

    // Expand on pick up by inheriting and overriding this function (Don't forget base.OnPuckUp())
    public virtual void OnPickUp(Collider2D collision)
    {
        gameObject.SetActive(false);

        //Play pickup sound
        if (GlobalReferenceManager.AudioManagerRef != null)
            GlobalReferenceManager.AudioManagerRef.PlaySound(pickUpAudioName);

        //Spawn pickup particle prefab
        if (particlePrefab != null)
        {
            GameObject newPickup = Instantiate(particlePrefab, transform.position, transform.rotation);
            Destroy(newPickup, particleDestroyTimer);
        }
    }
}
