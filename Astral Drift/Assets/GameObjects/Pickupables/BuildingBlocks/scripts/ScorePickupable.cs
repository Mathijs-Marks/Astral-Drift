using UnityEngine;

public class ScorePickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 1;
    [SerializeField] private float starAnimationTimer = 1f;

    public override void OnPickUp(Collider2D collision)
    {
        base.OnPickUp(collision);

        GlobalReferenceManager.AudioManagerRef.PlaySound("StarPickup");

        GameObject starPrefab = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(starPrefab, starAnimationTimer);
        UI.instance.AddScore(scoreIncrease);
    }
}
