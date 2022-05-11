using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementBehaviours : MonoBehaviour
{
    protected int currentHitpoints;

    public virtual void MoveRight(Transform movingObject, float speed)
    {
        movingObject.position += new Vector3(1 * speed, 0, 0);
    }
    public virtual void MoveLeft(Transform movingObject, float speed)
    {
        movingObject.position -= new Vector3(1 * speed, 0, 0);
    }
    public virtual void MoveForward(Transform movingObject, float speed)
    {
        movingObject.position -= new Vector3(0, 1 * speed, 0);
    }
    public virtual void MoveBackwards(Transform movingObject, float speed)
    {
        movingObject.position += new Vector3(0, 1 * speed, 0);
    }
    public virtual void CircleAround(Transform movingObject, Vector3 startPosition, float angle, float speed, float radius, float passedTime)
    {
        angle += speed * passedTime;
        Vector3 offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        movingObject.position = startPosition + offset;
    }

    //Enemy gets hit got hit
    public void GetHit(int damage)
    {
        currentHitpoints -= damage;

        if (currentHitpoints <= 0)
        {
            //TO DO: Enemy dies
            gameObject.SetActive(false);
        }
    }

}