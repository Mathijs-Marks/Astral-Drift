using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MovementBehaviours
{
    private GameObject playerTarget;
    private bool isRotating = true;
    
    // This code may be removed later, ask SDM
    //[Header("Rotating speed: 0 means no rotation, 1 means instant rotation.")]
    //[SerializeField] [Range(0, 1)] private float rotatingSpeed = 1;

    private void Start()
    {
        playerTarget = GlobalReferenceManager.PlayerPosition.gameObject;
        speed = Mathf.Clamp01(speed);
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            //Rotating
            Vector3 direction = playerTarget.transform.position - transform.position;
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
