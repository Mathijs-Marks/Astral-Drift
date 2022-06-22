using UnityEngine;

public class TravelingMovementBehaviours : MovementBehaviours
{
    [SerializeField] protected Vector2 direction;
    private float screenX;
    private void Start()
    {
        screenX = GlobalReferenceManager.ScreenCollider.sizeX / 2;
    }
    protected void OutOfBoundsCheck()
    {
        if (transform.position.x > screenX || transform.position.x < -screenX)
            direction *= -1;
    }
}