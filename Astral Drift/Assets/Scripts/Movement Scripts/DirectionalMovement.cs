using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MovementBehaviours
{
    [SerializeField] private Vector3 direction;

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
