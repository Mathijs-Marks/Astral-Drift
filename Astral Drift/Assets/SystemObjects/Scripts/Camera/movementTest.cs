using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    //[SerializeField] private BackgroundScroller background;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (GlobalReferenceManager.MainCamera == null)
        {
            GlobalReferenceManager.MainCamera = GetComponent<Camera>();
        }
    }
}
