using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxFactor;        // The speed at which the background moves relative to the desired effect
    public float movementSpeed;         // Speed at which the background moves (can be positive or negative)
    public float backgroundWidth;       // Width of the background layer (this helps for looping)

    private Vector3 initialPosition;    // Initial position of the background

    void Start()
    {
        // Record the initial position of the background
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the background over time (left direction)
        float parallaxMovement = movementSpeed * parallaxFactor * Time.deltaTime;

        // Apply the movement to the background position (on X-axis)
        transform.position = new Vector3(transform.position.x + parallaxMovement, transform.position.y, transform.position.z);

        // Loop the background when it moves off-screen to the left
        if (transform.position.x <= initialPosition.x - backgroundWidth)
        {
            transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
        }
    }
}