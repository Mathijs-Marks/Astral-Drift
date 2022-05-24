using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongRotate : MovementBehaviours
{
    [SerializeField] private float degreesToRotate;

    [Tooltip("This is the Z rotation this object will start rotating from")]
    [SerializeField] private float startingAngle;
    private void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.PingPong(Time.time * speed, degreesToRotate) + startingAngle);
    }
}