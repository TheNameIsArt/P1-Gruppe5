using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    public SpriteRenderer[] circleSprites; // Array to hold all circle objects
    private int currentIndex = 0; // Index of the circle to change color

    // Method to change the current circle's color to green
    public void CorrectButton()
    {
        if (circleSprites.Length == 0) return;

        
        circleSprites[currentIndex].color = Color.green; // Change current circle to green
        currentIndex = (currentIndex + 1) % circleSprites.Length; // Move to the next circle
    }

    // Method to change the current circle's color to red
    public void IncorrectButton()
    {
        if (circleSprites.Length == 0) return;

        
        circleSprites[currentIndex].color = Color.red; // Change current circle to red
        currentIndex = (currentIndex + 1) % circleSprites.Length; // Move to the next circle
    }
}
