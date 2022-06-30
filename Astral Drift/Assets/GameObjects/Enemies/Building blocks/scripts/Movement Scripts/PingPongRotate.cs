using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// See: https://docs.unity3d.com/ScriptReference/Mathf.PingPong.html
/// </summary>
public class PingPongRotate : MovementBehaviours
{
    [SerializeField] private float degreesToRotate = 90;

    [Tooltip("This is the Z rotation this object will start rotating from")]
    [SerializeField] private float startingAngle = -45;
    private void FixedUpdate()
    {
        DoPingPongRotate();
    }
    private void DoPingPongRotate()
    {
        if (degreesToRotate > 0) {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.PingPong(Time.time * speed, degreesToRotate) + startingAngle);
        } 
    }
}