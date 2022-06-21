using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 1;
    private Rigidbody2D rigidbody;
    private float randomDirectionX, randomDirectionY;
    [SerializeField] private GameObject starParticle;
    [SerializeField] private float starAnimationTimer = 1f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        randomDirectionX = Random.Range(-3, 3);
        randomDirectionY = Random.Range(-3, 3);
        rigidbody.AddForce(new Vector2(randomDirectionX, randomDirectionY), ForceMode2D.Impulse);
    }

    protected override void PickUp(Collider2D collision)
    {
        base.PickUp(collision);

        GameObject starPrefab = Instantiate(starParticle, transform.position, transform.rotation);
        Destroy(starPrefab, starAnimationTimer);
        UI.instance.AddScore(scoreIncrease);
    }
}
