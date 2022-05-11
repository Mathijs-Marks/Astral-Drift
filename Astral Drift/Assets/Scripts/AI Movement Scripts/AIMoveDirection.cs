using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveDirection : AIMovementBehaviours
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed = 0.1f;

    void FixedUpdate()
    {
        MoveDirection(transform, direction, speed);
    }
}
