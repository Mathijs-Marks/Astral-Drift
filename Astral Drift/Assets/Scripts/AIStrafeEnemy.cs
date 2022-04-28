using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStrafeEnemy : AIMovementBehaviours
{
    //THIS IS A TEMP ENEMY SCRIPT TO SHO HOW TO USE THE MOVEMENT BEHAVIOURS

    private Vector3 startpos;
    [SerializeField] private float speed = 2, movingTime = 4;
    private bool movingRight;
    private float passedTime;

    private void Start()
    {
        startpos = transform.position;
    }

    void FixedUpdate()
    {
        if (movingRight)
            MoveRight(transform, startpos, speed);
        else
            MoveLeft(transform, startpos, speed);

        passedTime += Time.deltaTime;
        if (passedTime > movingTime)
        {
            movingRight = !movingRight;
            passedTime = 0;
        }
    }
}
