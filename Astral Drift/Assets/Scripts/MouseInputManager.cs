using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MouseInputManager : MonoBehaviour
{
    private float depth = 10.0f;
    private Vector2 mousePosition;
    private Vector3 wantedPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            mousePosition = Input.mousePosition;
            wantedPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, depth));
            transform.position = wantedPosition;
        }
    }
}
