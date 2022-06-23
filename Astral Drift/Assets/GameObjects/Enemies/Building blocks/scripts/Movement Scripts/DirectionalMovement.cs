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
}
