using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckpointBehavior : MonoBehaviour
{
    public SpriteRenderer[] circleSprites; // Array to hold references to circle objects (SpriteRenderers)
    private int currentIndex = 0; // Index of the current circle to modify

    // Method to handle a "correct" DANOK Guess
    public void CorrectButton()
    {
        if (circleSprites.Length == 0) return; // If no circles are set, do nothing

        circleSprites[currentIndex].color = Color.green; // Change the current circle's color to green
        currentIndex = (currentIndex + 1) % circleSprites.Length; // Move to the next circle, looping back if at the end
    }

    // Method to handle an "incorrect" DANOK Guess
    public void IncorrectButton()
    {
        if (circleSprites.Length == 0) return; // If no circles are set, do nothing

        circleSprites[currentIndex].color = Color.red; // Change the current circle's color to red
        currentIndex = (currentIndex + 1) % circleSprites.Length; // Move to the next circle, looping back if at the end
    }

    // Method to reset all circles to their default color
    public void ResetCircles()
    {
        currentIndex = 0; // Reset the index to the first circle
        for (int i = 0; i < circleSprites.Length; i++)
        {
            circleSprites[i].color = Color.white; // Reset each circle's color to white (default)
        }
    }
}