using UnityEngine;

public class StrafeMovement : TravelingMovementBehaviours
{
    [SerializeField] private float xDistToMove = 1, yDistToMove = 0;
    [Tooltip("Choose between 1 and -1 to determine the direction")]
    private Vector3 startingPos;
    
    private void Start()
    {
        startingPos = transform.position;
        direction = new Vector2(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));
    }
    void FixedUpdate()
    {
        DoDirectionalMovement();
        InvertMovement();
        OutOfBoundsCheck();
    }
    private void InvertMovement()
    {
        //Invert X direction
        if (xDistToMove > 0)
            if (transform.position.x > startingPos.x + (xDistToMove / 2) || transform.position.x < startingPos.x - (xDistToMove / 2))
                direction.x *= -1;

        //Invert Y direction
        if (yDistToMove > 0)
            if (transform.position.y > startingPos.y + (yDistToMove / 2) || transform.position.y < startingPos.y - (yDistToMove / 2))
                direction.y *= -1;
    }
}