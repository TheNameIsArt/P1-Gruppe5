using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    // Reference to the UI GameObject
    GameObject UI;

    // Reference to the UIScript component attached to the UI GameObject
    UIScript UIScript;

    // Audio source to play the damage sound effect
    AudioSource DamageSound;

    private void Awake()
    {
        // Find the UI GameObject in the scene
        UI = GameObject.Find("UI");

        // Get the UIScript component from the UI GameObject
        UIScript = UI.GetComponent<UIScript>();

        // Get the AudioSource component attached to the player
        DamageSound = GetComponent<AudioSource>();
    }

    // Triggered when the player collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is on Layer 6 (e.g., an obstacle or enemy)
        if (collision.gameObject.layer == 6)
        {
            // Reduce the player's health by 1
            UIScript.health = UIScript.health - 1;

            // Play the damage sound if the player's health is still above 0
            if (UIScript.health >= 0)
            {
                DamageSound.Play();
            }

            // If health is 0 or less and the game isn't already marked as over
            if (UIScript.health <= 0 && UIScript.gameIsOver == false)
            {
                // Trigger the game-over functionality in the UIScript
                UIScript.gameOver();
            }
        }

        // Check if the collided object is on Layer 9 (e.g. the chest)
        if (collision.gameObject.layer == 9)
        {
            // Load the "DANOK" scene 
            SceneManager.LoadScene("DANOK");
        }
    }
}