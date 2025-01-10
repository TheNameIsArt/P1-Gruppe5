using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    // Speed at which the obstacle moves to the left
    public float moveSpeed = 5;

    // Position on the X-axis where the obstacle gets destroyed (out of bounds)
    public float deadZone = -20;

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle to the left at a constant speed
        // Time.deltaTime ensures the movement is frame-rate independent
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Check if the obstacle has moved past the dead zone
        if (transform.position.x < deadZone)
        {
            // Destroy the obstacle to free up resources
            Destroy(gameObject);
        }
    }
}