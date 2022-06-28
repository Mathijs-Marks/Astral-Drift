using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveViewer : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        this.transform.position += Vector3.up * speed;
    }
}
