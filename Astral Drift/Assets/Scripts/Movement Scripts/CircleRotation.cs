using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MovementBehaviours
{
    [SerializeField] private bool moveClockwise;

    private Vector3 targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Set rotation direction (vector z axis)
        targetRotation = new Vector3(0, 0, -1);
        if (!moveClockwise) targetRotation.z *= -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DoRotation();
    }
    private void DoRotation()
    {
        if (speed > 0)
        {
            //Rotate the object
            transform.Rotate(targetRotation * speed * Time.deltaTime, Space.Self);
        }
    }
}
