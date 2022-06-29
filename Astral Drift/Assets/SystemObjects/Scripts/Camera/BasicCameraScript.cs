using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraScript : MonoBehaviour
{
    public float speed;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (GlobalReferenceManager.MainCamera == null)
        {
            GlobalReferenceManager.MainCamera = GetComponent<Camera>();
        }
    }
    void FixedUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        this.transform.position += Vector3.up * speed;
    }
}
