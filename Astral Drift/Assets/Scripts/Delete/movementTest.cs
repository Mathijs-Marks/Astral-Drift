using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    [SerializeField] private BackgroundScroller background;
    private void Start()
    {
        if(GlobalReferenceManager.MainCamera == null)
        {
            GlobalReferenceManager.MainCamera = GetComponent<Camera>();
        }
    }
    void FixedUpdate()
    {
        if (background.cameraMovement)
        {
            transform.position += Vector3.up * background.moveSpeed;
        }
    }
}
