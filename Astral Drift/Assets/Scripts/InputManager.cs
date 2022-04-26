using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class InputManager : MonoBehaviour
{
    // Position of the circle.
    private Vector2 objectPosition;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        // Set the position to the center.
        objectPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the touchCount is greater than zero, that means we are touching the screen.
        if (Input.touchCount > 0)
        {
            // Begin touch
            Touch touch = Input.GetTouch(0);

            // Move the circle if the finger is moving over the screen.
            if (touch.phase == TouchPhase.Moved)
            {
                // Get the vector position of the finger touching.
                Vector2 touchPosition = touch.position;
                touchPosition.x = (touchPosition.x - width) / width;
                touchPosition.y = (touchPosition.y - height) / height;
                // Assign the position of the object to the position of the finger.
                objectPosition = new Vector2(-touchPosition.x, touchPosition.y);

                // Move the object.
                transform.position = objectPosition;
            }
        }
    }
}
