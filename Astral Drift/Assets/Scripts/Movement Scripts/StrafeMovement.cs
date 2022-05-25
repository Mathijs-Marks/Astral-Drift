using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeMovement : MovementBehaviours
{
    [SerializeField] private float xDistToMove, yDistToMove;
    [Tooltip("Choose between 1 and -1 to determine the direction")]
    [SerializeField] private Vector2 direction = new Vector2(1, 0);
    private Vector3 startingPos;
    
    private void Start()
    {
        startingPos = transform.position;
        direction = new Vector2(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));
    }
    void FixedUpdate()
    {
        if (xDistToMove > 0 || yDistToMove > 0)
            transform.position += (Vector3)direction * speed * Time.deltaTime;

        //Invert X direction
        if(xDistToMove > 0)
            if(transform.position.x > startingPos.x + (xDistToMove / 2) || transform.position.x < startingPos.x - (xDistToMove / 2))
                direction.x *= -1;

        //Invert Y direction
        if (yDistToMove > 0)
            if (transform.position.y > startingPos.y + (yDistToMove / 2) || transform.position.y < startingPos.y - (yDistToMove / 2))
                direction.y *= -1;
    }
}
