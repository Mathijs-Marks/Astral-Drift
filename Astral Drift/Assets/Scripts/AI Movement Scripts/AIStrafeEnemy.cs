using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStrafeEnemy : AIMovementBehaviours
{
    //THIS IS A TEMP ENEMY SCRIPT TO SHO HOW TO USE THE MOVEMENT BEHAVIOURS

    [SerializeField] private float speed = 0.1f, movingTime = 2;
    private bool movingRight;
    private float passedTime;

    void FixedUpdate()
    {
        if (movingRight)
            MoveRight(transform, speed);
        else
            MoveLeft(transform, speed);

        passedTime += Time.deltaTime;
        if (passedTime > movingTime)
        {
            movingRight = !movingRight;
            passedTime = 0;
        }
    }
}
