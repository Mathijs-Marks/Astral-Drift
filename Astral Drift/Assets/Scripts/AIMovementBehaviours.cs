using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementBehaviours : MonoBehaviour
{
    public virtual void MoveRight(Transform movingObject, Vector3 startPosition, float speed)
    {
        movingObject.position += new Vector3(Mathf.Sin(Time.deltaTime) * speed, 0, 0);
    }
    public virtual void MoveLeft(Transform movingObject, Vector3 startPosition, float speed)
    {
        movingObject.position -= new Vector3(Mathf.Sin(Time.deltaTime) * speed, 0, 0);
    }
    public virtual void CircleAround(Transform movingObject, Vector3 startPosition, float angle, float speed, float radius)
    {
        angle += speed * Time.deltaTime;
        movingObject.position -= new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
    }
    IEnumerator ZigZag(GameObject movingObject)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0;
        float duration = 0.2f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, startPosition, elapsed / duration);
            yield return null;
        }
        transform.position = startPosition;

        //When one zigzag is completed start zigzagging again
        StartCoroutine(ZigZag(movingObject));
    }
}