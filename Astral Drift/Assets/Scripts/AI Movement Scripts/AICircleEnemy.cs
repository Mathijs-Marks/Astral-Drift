using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICircleEnemy : AIMovementBehaviours
{
    private Vector3 startpos;
    [SerializeField] private float angle = 1, radius = 1;
    private float passedTime = 0;
    private void Start()
    {
        startpos = transform.position;
    }
    void FixedUpdate()
    {
        angle += speed * passedTime;
        Vector3 offset = startpos;
        offset += startpos - new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        transform.position = startpos + offset;

        passedTime += Time.deltaTime;
    }
}
