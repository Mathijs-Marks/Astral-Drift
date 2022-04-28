using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : AIMovementBehaviours
{
    private Vector3 startpos;
    private float angle = 1, speed = 0.1f, radius = 3;
    private void Start()
    {
        startpos = transform.position;
    }

    //THIS IS A TEMP ENEMY SCRIPT TO SHO HOW TO USE THE MOVEMENT BEHAVIOURS
    void FixedUpdate()
    {
        MoveRight(transform, startpos, 2);
        //CircleAround(transform, startpos, angle, speed, radius);
    }
}
