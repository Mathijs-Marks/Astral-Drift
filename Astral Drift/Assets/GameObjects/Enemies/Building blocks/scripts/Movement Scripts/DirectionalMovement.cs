using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : TravelingMovementBehaviours
{
    void FixedUpdate()
    {
        DoDirectionalMovement();
        OutOfBoundsCheck();
    }
    private void DoDirectionalMovement()
    {
        Vector2 Offset = direction * speed * Time.deltaTime;
        transform.position += (Vector3)Offset;
    }
}
