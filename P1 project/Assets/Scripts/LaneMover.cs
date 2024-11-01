using UnityEngine;

// @kurtdekker - lane-based mover
//
// To use:
// Drop this on your player object
// Move your camera to see it go into the distance (see note about 2D below)
// press PLAY
// use A and D to change lanes

public class LaneMover : MonoBehaviour
{
    private int laneNumber;

    const int MaxLanes = 3;
    
    //Change lane size
    const float LaneWidth = 3f;

    const float LaneZeroXPosition = -LaneWidth * (MaxLanes - 1) / 2.0f;

    const float LateralLaneMoveSpeed = 10.0f;

    //const float ForwardPlayerSpeed = 5.0f;

    void Update()
    {
        // gather input to change lanes
        if (Input.GetKeyDown(KeyCode.A)) laneNumber--;
        if (Input.GetKeyDown(KeyCode.D)) laneNumber++;

        // now guard laneNumber to MaxLanes lanes
        if (laneNumber < 0) laneNumber = 0;
        if (laneNumber > MaxLanes - 1) laneNumber = MaxLanes - 1;

        // where should we be for this lane?
        float laneXPosition = laneNumber * LaneWidth + LaneZeroXPosition;

        // working copy
        Vector3 position = transform.position;

        // compute desired lateral position
        position.x = Mathf.MoveTowards(
                   position.x,
                   laneXPosition,
                   LateralLaneMoveSpeed * Time.deltaTime);

        // move the player downrange if desired (change this to position.z for 3D games!)
        //position.y += ForwardPlayerSpeed * Time.deltaTime;

        // off we go (replace with Rigidbody/Rigidbody2D.MovePosition() if using physics!)
        transform.position = position;
    }
}