using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D playerBody;

    [SerializeField] private int speed = 5;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value) 
    { 
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        playerBody.velocity = movement * speed;
    }
}
