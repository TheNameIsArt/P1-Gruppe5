using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeTest : MonoBehaviour
{
    private PlayerInput _controls;

    [SerializeField] private float minimumSwipeMagnitude = 10f;
    private Vector2 _swipeDirection;
    public LaneMover LaneMover;

    void Start()
    {
        _controls = new PlayerInput();
        _controls.Player.Enable();
        _controls.Player.Touch.canceled += ProcessTouchComplete;
        _controls.Player.Swipe.performed += ProcessSwipeDelta;
        LaneMover = GetComponent<LaneMover>();
    }
    private void ProcessSwipeDelta(InputAction.CallbackContext context) 
    {
        _swipeDirection = context.ReadValue<Vector2>();
    }

    private void ProcessTouchComplete(InputAction.CallbackContext context)
    {
        //check if the magnitude is high enough
        Debug.Log("Touch complete");
        if (Mathf.Abs(_swipeDirection.magnitude) < minimumSwipeMagnitude) return;
        Debug.Log("Swipe detected");
        
        var position = Vector3.zero;

        //check horizontal direction
        //if (_swipeDirection.x > 0) 
        {
            Debug.Log("Swiping right");
        }
        //else if (_swipeDirection.x < 0)
        {
            Debug.Log("Swiping left");
        }

        //check vertical direction
        if (_swipeDirection.y > 0)
        {
            Debug.Log("Swiping up");
            LaneMover.laneNumber++;
        }
        else if (_swipeDirection.y < 0)
        {
            Debug.Log("Swiping down");
            LaneMover.laneNumber--;
        }
    }
}