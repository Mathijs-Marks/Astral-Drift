using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementBehaviours : MonoBehaviour
{
    public static AIMovementBehaviours instance;
    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public void MoveObject(enums.MovementBehaviour behaviour, GameObject movingObject)
    {
        switch (behaviour)
        {
            case enums.MovementBehaviour.RightToLeft:
                StartCoroutine(RightToLeft(movingObject));
                break;
            case enums.MovementBehaviour.LeftToRight:
                StartCoroutine(LeftToRight(movingObject));
                break;
            case enums.MovementBehaviour.Circle:
                StartCoroutine(Circle(movingObject));
                break;
            case enums.MovementBehaviour.ZigZag:
                StartCoroutine(ZigZag(movingObject));
                break;
        }
    }
    IEnumerator RightToLeft(GameObject movingObject)
    {
        //Do movement code
        yield return null;

        //When one iteration is complete start moving left to right again;
        StartCoroutine(LeftToRight(movingObject));
    }
    IEnumerator LeftToRight(GameObject movingObject)
    {
        //Do movement code
        yield return null;

        //When one iteration is complete start moving left to right again;
        StartCoroutine(LeftToRight(movingObject));
    }
    IEnumerator Circle(GameObject movingObject)
    {
        //Do movement code
        yield return null;

        //When one full circle is completed start circling again
        StartCoroutine(Circle(movingObject));
    }
    IEnumerator ZigZag(GameObject movingObject)
    {
        //Do movement code
        yield return null;

        //When one zigzag is completed start zigzagging again
        StartCoroutine(ZigZag(movingObject));
    }
}