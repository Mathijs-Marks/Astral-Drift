using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    [SerializeField] private BackgroundScroller background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (background.cameraMovement)
        {
        this.transform.position += Vector3.up * background.moveSpeed;
        }
    }
}
