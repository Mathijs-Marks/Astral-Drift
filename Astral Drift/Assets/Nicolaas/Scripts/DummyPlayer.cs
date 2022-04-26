using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a testing script that can be removed later.
public class DummyPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private int direction;
    private Vector2 directionVector = new Vector2(1, 0);


    // Controls
    private void FixedUpdate()
    {
        direction = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction++;
        }

        transform.Translate(directionVector * direction * speed);
    }

    // Testing if you got hit
    public void GetHit(int damage)
    {
        Debug.Log("Player got hit. Reduce hitpoints. Hit for " + damage + " damage.");
    }
}
