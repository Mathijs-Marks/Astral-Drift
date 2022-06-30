using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MovementBehaviours
{
    private GameObject playerTarget;
    private bool isRotating = true;

    private void Start()
    {
        playerTarget = GlobalReferenceManager.PlayerPosition.gameObject;
        speed = Mathf.Clamp01(speed);
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            //Rotate towards player
            Vector3 direction = transform.position - playerTarget.transform.position;
            Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.forward);
            rotation.x = transform.rotation.x;
            rotation.y = transform.rotation.y;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed);
        }
    }

    public void SetIsRotating(bool value)
    {
        isRotating = value;
    }
}
