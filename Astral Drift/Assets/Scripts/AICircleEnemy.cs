using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICircleEnemy : AIMovementBehaviours
{
    private Vector3 startpos;
    [SerializeField] private float angle = 1, speed = 0.1f, radius = 3;
    private float passedTime = 0;
    private void Start()
    {
        startpos = transform.position;
    }

    //THIS IS A TEMP ENEMY SCRIPT TO SHO HOW TO USE THE MOVEMENT BEHAVIOURS
    void FixedUpdate()
    {        
        CircleAround(transform, startpos, angle, speed, radius, passedTime);
        passedTime += Time.deltaTime;
    }
}
