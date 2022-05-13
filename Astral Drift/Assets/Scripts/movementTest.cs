using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    [SerializeField] private BackgroundScroller background;
    void FixedUpdate()
    {
        if (background.cameraMovement)
        {
        transform.position += Vector3.up * background.moveSpeed;
        }
    }
}
