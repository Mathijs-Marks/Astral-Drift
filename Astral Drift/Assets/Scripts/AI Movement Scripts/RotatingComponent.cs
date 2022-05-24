using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingComponent : AIMovementBehaviours
{
    [SerializeField] private float minDegreesToRotate = -180, maxDegreesToRotate = 180;
    [SerializeField] private bool moveClockwise;

    private Vector3 targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Clamp degrees to rotate
        minDegreesToRotate = Mathf.Clamp(minDegreesToRotate, -180f, 0f);
        maxDegreesToRotate = Mathf.Clamp(maxDegreesToRotate, 0f, 180f);

        //Set rotation direction (vector z axis)
        targetRotation = new Vector3(0, 0, -1);
        if (!moveClockwise) targetRotation.z *= -1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed > 0)
        {
            //Rotate the object
            transform.Rotate(targetRotation * speed * Time.deltaTime, Space.Self);

            //Here we check if the object should be able to rotate backwards depending on the degreesToRotate
            if (minDegreesToRotate < 0)
            {
                if (moveClockwise)
                {
                    if (transform.localEulerAngles.z <= minDegreesToRotate)
                    {
                        //invert rotate direction
                        targetRotation.z *= -1;
                    }
                }
                else
                {
                    if (transform.localEulerAngles.z >= maxDegreesToRotate)
                    {
                        //invert rotate direction
                        targetRotation.z *= -1;
                    }
                }
            }
        }

    }
}
