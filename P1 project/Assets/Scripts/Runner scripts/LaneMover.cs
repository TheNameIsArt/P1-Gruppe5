using UnityEngine;

// @kurtdekker - lane-based mover
//
// To use:
// Drop this on your player object
// Move your camera to see it go into the distance (see note about 2D below)
// press PLAY
// use W and S to change lanes

public class LaneMover : MonoBehaviour
{
    public int laneNumber;

    const int MaxLanes = 3;

    //Change lane size
    const float LaneWidth = 3f;

    const float LaneZeroYPosition = -LaneWidth * (MaxLanes - 1) / 2.0f;

    const float LateralLaneMoveSpeed = 10.0f;

    // Enable if you want the character to move forward
    //const float ForwardPlayerSpeed = 5.0f;

    void Update()
    {
        // gather input to change lanes

        //if (Input.GetKeyDown(KeyCode.S)) laneNumber--;
        //if (Input.GetKeyDown(KeyCode.W)) laneNumber++;

        // now guard laneNumber to MaxLanes lanes
        if (laneNumber < 0) laneNumber = 0;
        if (laneNumber > MaxLanes - 1) laneNumber = MaxLanes - 1;

        // where should we be for this lane?
        float laneYPosition = laneNumber * LaneWidth + LaneZeroYPosition;

        // working copy
        Vector3 position = transform.position;

        // compute desired lateral position
        position.y = Mathf.MoveTowards(
                   position.y,
                   laneYPosition,
                   LateralLaneMoveSpeed * Time.deltaTime);

        // move the player downrange if desired (change this to position.z for 3D games!)
        //position.y += ForwardPlayerSpeed * Time.deltaTime;

        // off we go (replace with Rigidbody/Rigidbody2D.MovePosition() if using physics!)
        transform.position = position;
    }
}