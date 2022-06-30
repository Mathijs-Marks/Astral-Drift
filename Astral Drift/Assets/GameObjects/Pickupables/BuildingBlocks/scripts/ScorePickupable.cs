using UnityEngine;

public class ScorePickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 1;
    [SerializeField] private float starAnimationTimer = 1f;

    public override void OnPickUp(Collider2D collision)
    {
        base.OnPickUp(collision);

        UI.instance.AddScore(scoreIncrease);
    }
}
