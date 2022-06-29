using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
   /* private DefaultMovement _movement;
    private PlayerRotation _rotation;

    private int _amountOfTouchPoints = 0;
    private int _savedTouchPoints = 0;
    private Vector3 _cursorPosition;

    // Start is called before the first frame update
    void Start()
    {
        // get the different components that the inputhandler will handle
        _movement = GetComponent<DefaultMovement>();
        _rotation = GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        // check platform for input
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                _amountOfTouchPoints = Input.GetMouseButtonDown(0) ? 1 : (Input.GetMouseButtonUp(0) ? 0 : _amountOfTouchPoints);
                _cursorPosition = Input.mousePosition;
                break;
            default:
                _amountOfTouchPoints = Input.touchCount;
                _cursorPosition = Input.GetTouch(0).position;
                break;
        }

        CheckAmountOfFingers(_amountOfTouchPoints);

        if (_amountOfTouchPoints > 0)
        {
            // set the location to move towards
            _movement.SetPosition(_cursorPosition);

            // rotate
            _rotation.Rotate();
        }
    }

    private void FixedUpdate()
    {
        if(_amountOfTouchPoints == 0)
            _movement.SmoothOut();
    }

    // handles a change in amount of fingers
    private void CheckAmountOfFingers(int amountOfFingers)
    {
        if(_savedTouchPoints != amountOfFingers)
        {
            _savedTouchPoints = amountOfFingers;
            OnFingerAmountChanged();
            CheckIfShipReset();
        }
    }

    private void CheckIfShipReset()
    {
        // reset rotation if no touchpoints
        _rotation.ResetShipRotation(_savedTouchPoints == 0);
    }

    private void OnFingerAmountChanged()
    {
       // update position if 0 touchpoints
        if(_savedTouchPoints == 0)
        {
            _movement.NoPosition();
        }
    }*/
}
