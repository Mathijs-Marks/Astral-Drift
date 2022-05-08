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
    private bool mousePointer;

    // Update is called once per frame
    void Update()
    {
        // Get current pointer position of the mouse.
        mousePointer = EventSystem.current.IsPointerOverGameObject();

        // If there's a mouse click and if the cursor is not hovering over a game object, then move the player towards the cursor position.
        if (Input.GetMouseButton(0) && !mousePointer)
        {
            mousePosition = Input.mousePosition;
            wantedPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, depth));
            transform.position = wantedPosition;
        }
    }
}
