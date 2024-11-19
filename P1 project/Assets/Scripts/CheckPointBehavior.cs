using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckpointBehavior : MonoBehaviour
{
    public Image circleImage; // Reference to the circle's Image component
    public Button CorrectButton; // Reference to the green button
    public Button IncorrectButton; // Reference to the red button

    void Start()
    {
        // Attach the button click events
        if (CorrectButton != null)
            CorrectButton.onClick.AddListener(SetGreenColor);

        if (IncorrectButton != null)
            IncorrectButton.onClick.AddListener(SetRedColor);
    }

    void SetGreenColor()
    {
        // Set the circle's color to green
        if (circleImage != null)
            circleImage.color = Color.green;
    }

    void SetRedColor()
    {
        // Set the circle's color to red
        if (circleImage != null)
            circleImage.color = Color.red;
    }
}
