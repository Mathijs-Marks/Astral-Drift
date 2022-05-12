using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveDirection : AIMovementBehaviours
{
    [SerializeField] private Vector3 direction;

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
