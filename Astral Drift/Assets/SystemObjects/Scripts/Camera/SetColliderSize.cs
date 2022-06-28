using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SetColliderSize : MonoBehaviour
{
    private Camera mainCam;
    private Collider2D ownCollider;
    [HideInInspector] public float sizeX, sizeY, ratio;
    // Start is called before the first frame update
    private void Awake()
    {
        if(GlobalReferenceManager.ScreenCollider == null)
            GlobalReferenceManager.ScreenCollider = this;
    }
    private void Start()
    {
        SetColliderWidthAndHeight();
    }

    public void SetColliderWidthAndHeight()
    {
        mainCam = GlobalReferenceManager.MainCamera;
        ownCollider = GetComponent<BoxCollider2D>();
        sizeY = mainCam.orthographicSize * 2;
        ratio = (float)Screen.width / (float)Screen.height;
        sizeX = sizeY * ratio;
        ownCollider.transform.localScale = new Vector3(sizeX, sizeY, 0);
    }
}
