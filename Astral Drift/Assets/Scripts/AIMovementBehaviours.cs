using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementBehaviours : MonoBehaviour
{
    public virtual void MoveRight(Transform movingObject, Vector3 startPosition, float speed)
    {
        movingObject.position += new Vector3(1 * speed, 0, 0);
    }
    public virtual void MoveLeft(Transform movingObject, Vector3 startPosition, float speed)
    {
        movingObject.position -= new Vector3(1 * speed, 0, 0);
    }
    public virtual void CircleAround(Transform movingObject, Vector3 startPosition, float angle, float speed, float radius, float passedTime)
    {
        angle += speed * passedTime;
        Vector3 offset = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;
        movingObject.position = startPosition + offset;
    }
}