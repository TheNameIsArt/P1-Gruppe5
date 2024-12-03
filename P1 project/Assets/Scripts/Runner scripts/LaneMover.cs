using UnityEngine;

public class LaneMover : MonoBehaviour
{
    public int laneNumber;
    public float[] laneYPositions;

    const float LateralLaneMoveSpeed = 5f;

    void Update()
    {
        // Gather input to change lanes
        if (Input.GetKeyDown(KeyCode.S)) laneNumber--;
        if (Input.GetKeyDown(KeyCode.W)) laneNumber++;

        // Guard laneNumber to valid range
        if (laneNumber < 0) laneNumber = 0;
        if (laneNumber > laneYPositions.Length - 1) laneNumber = laneYPositions.Length - 1;

        // Target position for the current lane
        float laneYPosition = laneYPositions[laneNumber];

        // Working copy of the player's position
        Vector3 position = transform.position;

        // Smoothly move towards target Y position
        position.y = Mathf.MoveTowards(position.y, laneYPosition, LateralLaneMoveSpeed * Time.deltaTime);

        // Update position
        transform.position = position;
    }
}