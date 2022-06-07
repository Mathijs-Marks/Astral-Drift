using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MovementBehaviours
{
    [SerializeField] private Vector2 direction = new Vector2(1, 0);

    void FixedUpdate()
    {
        DoDirectionalMovement();
    }
    private void DoDirectionalMovement()
    {
        Vector2 Offset = direction * speed * Time.deltaTime;
        transform.position += (Vector3)Offset;
    }
}
