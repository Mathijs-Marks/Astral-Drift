using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementBehaviours : MonoBehaviour
{
    protected int currentHitpoints;
    [SerializeField] public int maxHitpoints = 2;

    public virtual void MoveDirection(Transform movingObject, Vector3 direction, float speed)
    {
        direction.Normalize();
        movingObject.position += direction * speed;
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