using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MovementBehaviours
{
    [SerializeField] private float radius = 1; //Radius of circle to move in
    private float passedTime = 0, angle, radiusDivider = 25;

    void FixedUpdate()
    {
        DoCircularMovement();
    }
    private void DoCircularMovement()
    {
        angle = speed * passedTime;
        Vector3 offsetPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius / radiusDivider;
        transform.position += offsetPos;
        passedTime += Time.deltaTime;
    }
}
