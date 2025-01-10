using UnityEngine;

public class LaneMover : MonoBehaviour
{
    public int laneNumber = 1; //players starting lane
    private float[] laneYPositions = {-5f, -3.5f, -1.5f}; //Array of y-positions for lanes. Also determins amount of lanes

    public float LateralLaneMoveSpeed = 10f; //speed when lane-switching

    void Update()
    {
        // Gather input to change lanes
        if (Input.GetKeyDown(KeyCode.S)) laneNumber--;
        if (Input.GetKeyDown(KeyCode.W)) laneNumber++;

        // Guard laneNumber to valid range (so you don't go out of bounds)
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