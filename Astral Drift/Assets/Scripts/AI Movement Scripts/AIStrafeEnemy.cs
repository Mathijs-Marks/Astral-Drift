using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStrafeEnemy : AIMovementBehaviours
{
    [SerializeField] private float movingTime = 2;
    private bool movingRight;
    private float passedTime;

    void FixedUpdate()
    {
        if (movingRight)
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        else
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;

        passedTime += Time.deltaTime;
        if (passedTime > movingTime)
        {
            movingRight = !movingRight;
            passedTime = 0;
        }
    }
}
