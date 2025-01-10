using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeTest : MonoBehaviour
{
    // Private reference to the PlayerInput class (generated from Input System)
    private PlayerInput _controls;

    // Minimum magnitude of swipe movement required to register a swipe
    [SerializeField] private float minimumSwipeMagnitude = 10f;

    // Vector to store the direction of the swipe
    private Vector2 _swipeDirection;

    // Reference to the LaneMover script that handles lane movement
    public LaneMover LaneMover;

    void Start()
    {
        // Initialize the PlayerInput instance
        _controls = new PlayerInput();

        // Enable the "Player" action map to start listening for input
        _controls.Player.Enable();

        // Subscribe to the "Touch" action's "canceled" event
        // Triggered when the touch ends
        _controls.Player.Touch.canceled += ProcessTouchComplete;

        // Subscribe to the "Swipe" action's "performed" event
        // Triggered when swipe movement is detected
        _controls.Player.Swipe.performed += ProcessSwipeDelta;

        // Find the LaneMover script attached to the "Player" GameObject
        LaneMover = GameObject.Find("Player").GetComponent<LaneMover>();
    }

    // Called when a swipe input is detected
    private void ProcessSwipeDelta(InputAction.CallbackContext context)
    {
        // Read the swipe vector (e.g., direction and magnitude) from the input context
        _swipeDirection = context.ReadValue<Vector2>();
    }

    // Called when a touch input ends
    private void ProcessTouchComplete(InputAction.CallbackContext context)
    {
        // Check if the swipe magnitude meets the minimum required to be considered valid
        if (Mathf.Abs(_swipeDirection.magnitude) < minimumSwipeMagnitude) return;

       

        // Check the horizontal component of the swipe direction (not used in this project)
        if (_swipeDirection.x > 0)
        {
            // Swipe right detected
            //Debug.Log("Swiping right");
        }
        else if (_swipeDirection.x < 0)
        {
            // Swipe left detected
            //Debug.Log("Swiping left");
        }

        // Check the vertical component of the swipe direction (not used in this project)
        if (_swipeDirection.y > 0)
        {
            // Swipe up detected
            //Debug.Log("Swiping up");
            LaneMover.laneNumber++; // Move to the next lane upwards
        }
        else if (_swipeDirection.y < 0)
        {
            // Swipe down detected
            //Debug.Log("Swiping down");
            LaneMover.laneNumber--; // Move to the next lane downwards
        }
    }
}