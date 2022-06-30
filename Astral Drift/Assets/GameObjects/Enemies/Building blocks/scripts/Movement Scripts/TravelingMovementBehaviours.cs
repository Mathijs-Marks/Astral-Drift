using UnityEngine;

public class TravelingMovementBehaviours : MovementBehaviours
{
    [SerializeField] protected Vector2 direction;

    protected void OutOfBoundsCheck()
    {
        //Inverts movement if object moves out of bounds
        if (transform.position.x > GlobalReferenceManager.ScreenCollider.sizeX / 2 || transform.position.x < -GlobalReferenceManager.ScreenCollider.sizeX / 2)
            direction.x *= -1;
        if(transform.position.y > GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y)
            direction.y *= -1;
    }
    protected void DoDirectionalMovement()
    {
        //Do directional based movement
        Vector2 Offset = direction * speed * Time.deltaTime;
        transform.position += (Vector3)Offset;
    }
}