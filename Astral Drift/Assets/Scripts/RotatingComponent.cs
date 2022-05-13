using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingComponent : MonoBehaviour
{
    [SerializeField] private float RotatingSpeed;
    [SerializeField] private float degreesToRotate;
    [SerializeField] private bool moveClockwise;

    private Vector3 targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Clamp degrees to rotate
        degreesToRotate = Mathf.Clamp(degreesToRotate,0f, 359f);

        //Set rotation direction (vector z axis)
        targetRotation = new Vector3(0, 0, -1);
        if (!moveClockwise) targetRotation.z *= -1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RotatingSpeed > 0)
        {
            //Rotate the object
            transform.Rotate(targetRotation * RotatingSpeed * Time.fixedDeltaTime, Space.Self);

            //Here we check if the object should be able to rotate backwards depending on the degreesToRotate
            if (degreesToRotate > 0)
            {
                if (moveClockwise)
                {
                    if (transform.localEulerAngles.z <= 360 - degreesToRotate)
                    {
                        //invert rotate direction
                        targetRotation.z *= -1;
                    }
                }
                else
                {
                    if (transform.localEulerAngles.z >= degreesToRotate)
                    {
                        //invert rotate direction
                        targetRotation.z *= -1;
                    }
                }
            }
        }

    }
}
