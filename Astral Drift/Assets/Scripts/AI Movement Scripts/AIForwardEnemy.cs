using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIForwardEnemy : AIMovementBehaviours
{
    [SerializeField] private float speed = 0.1f;
    
    void FixedUpdate()
    {
        MoveDirection(transform, Vector3.down, speed);
    }
}
