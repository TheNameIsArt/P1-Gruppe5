using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class UIScript : MonoBehaviour
{
    // Array of GameObjects representing heart icons for player health
    public GameObject[] hearts;

    // Tracks whether the game is over
    public bool gameIsOver;

    // Player's health (number of hearts)
    public int health = 3;

    // UI text elements for displaying lives and gold. (Lives isn't used anymore since we now have hearts)
    public TMP_Text Lives;
    public TMP_Text GoldTxt;

    // GameObject for the Game Over screen
    public GameObject GameOverSceen;

    // ProgressBar and checkpoint management
    ProgressBar ProgressBarScript;
    CheckpointBehavior CheckpointBehavior;

    // References to other UI elements
    public GameObject ProgressBarObject;
    public GameObject Hearts;

    // Counters for correct and incorrect answers (used for DANOK)
    public int correctAnswersGotten;
    public int incorrectAnswersGotten;

    // Player's gold count
    public int Gold;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the ProgressBar component
        ProgressBarScript = GameObject.Find("Progress Bar").GetComponent<ProgressBar>();

        // Update the heart UI to reflect the initial health
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update the heart UI and gold display
        UpdateHearts();
        UpdateGold();
    }

    // LateUpdate is called after all Update calls
    /*void LateUpdate()
    {
        // Update the lives display text if the game isn't over
        if (!gameIsOver)
        {
            Lives.text = "Lives: " + health;
        }
    }*/

    // Updates the heart icons based on the player's current health
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Activate hearts if within the current health, deactivate otherwise
            if (i < health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

 

    // Triggers the game over state
    public void gameOver()
    {
        gameIsOver = true; // Mark the game as over
        GameOverSceen.SetActive(true); // Show the Game Over screen
        Time.timeScale = 0; // Pause the game
    }

    // Resets the level to its initial state
    public void ResetLevel()
    {
        Time.timeScale = 1; // Resume the game
        gameIsOver = false; // Reset game-over state
        health = 3; // Restore full health

        GameOverSceen.SetActive(false); // Hide the Game Over screen
        ProgressBarScript.ResetProgressBar(); // Reset the progress bar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Toggles the game between paused and unpaused states
    public void Pausebutton()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Time.timeScale = 1; // Resume the game
        }
    }

    // Updates the UI to reflect a win state
    public void WinScene()
    {
        ProgressBarObject.SetActive(false); // Hide the progress bar
        Hearts.SetActive(false); // Hide the hearts
    }

    // Updates the gold display text
    void UpdateGold()
    {
        GoldTxt.text = "Guld: " + Gold;
    }

    // Prepares the UI for the next level
    public void NextLvl()
    {
        ProgressBarObject.SetActive(true); // Show the progress bar
        Hearts.SetActive(true); // Show the hearts
        ProgressBarScript.ResetProgressBar(); // Reset the progress bar
        health = 3; // Restore full health
    }
}