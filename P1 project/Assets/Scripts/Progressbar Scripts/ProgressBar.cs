using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class ProgressBar : MonoBehaviour
{
    private Slider progressBar; // Reference to the progress bar UI element
    public float fillSpeed = 0.008f; // Speed at which the bar fills
    private float targetProgress = 0; // Where the bar currently is
    private bool isPaused = false; // Indicates if the progress bar is paused
    public static ProgressBar Instance; // Singleton instance for easy access
    string currentLevelName; // Tracks the current scene name
    CheckpointBehavior CheckpointBehavior; // Reference to CheckpointBehavior
    ObstacleSpawnScript ObstacleSpawnScript; // Reference to the obstacle spawning script

    public GameObject Spawner; // Spawner object responsible for creating obstacles

    // List of points at which the progress bar will pause (e.g., checkpoints or events)
    private List<float> pausePoints = new List<float> { 0.25f, 0.5f, 0.75f, 1f };

    private void Awake()
    {
        // Initialize the progress bar component
        progressBar = gameObject.GetComponent<Slider>();

        // Prevent the progress bar object from being destroyed when changing scenes
        DontDestroyOnLoad(gameObject);

        // Subscribe to the SceneManager's sceneLoaded event to handle scene transitions
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // Start the progress bar with an initial target progress
        IncrementProgress(1f);
    }

    private void Update()
    {
        // Update the progress bar value if it's not paused
        if (!isPaused && progressBar.value < targetProgress)
        {
            progressBar.value += fillSpeed * Time.deltaTime;

            // Check if the current progress has reached a pause point
            foreach (float pausePoint in pausePoints)
            {
                //Ensures that it only triggers once when reaching a checkpoint
                if (progressBar.value >= pausePoint && progressBar.value < pausePoint + fillSpeed * Time.deltaTime)
                {
                    if (pausePoint == pausePoints[pausePoints.Count - 1]) // Final pause point (progress complete)
                    {
                        Debug.Log("Final point reached!");
                        SceneManager.LoadScene("Win Scene"); // Load the win scene
                    }
                    else
                    {
                        PauseProgress(); // Pause the progress bar
                    }
                    break;
                }
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinitialize scene-specific objects
        Spawner = GameObject.Find("Spawner");
        if (Spawner != null)
        {
            ObstacleSpawnScript = Spawner.GetComponent<ObstacleSpawnScript>();
        }
    }

    // Adds progress to the bar by increasing the target value
    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBar.value + newProgress;
    }

    // Pauses the progress bar and triggers associated events (e.g., spawning a chest)
    public void PauseProgress()
    {
        isPaused = true; // Set the paused state
        currentLevelName = SceneManager.GetActiveScene().name; // Store the current scene name
        Debug.Log("Last Level Scene Name: " + currentLevelName);

        // Trigger chest spawning if the spawner is present
        if (ObstacleSpawnScript != null)
        {
            ObstacleSpawnScript.ChestSpawner();
        }

        // Disable the spawner to stop spawning obstacles
        if (Spawner != null)
        {
            Spawner.SetActive(false);
        }
    }

    // Resumes the progress bar and reloads the scene if necessary
    public void ResumeProgress()
    {
        isPaused = false; // Resume progress bar updates

        // Reload the current scene or a default scene if no current level is stored
        if (currentLevelName != null)
        {
            SceneManager.LoadScene(currentLevelName);
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }

    // Resets the progress bar and reinitializes related objects
    public void ResetProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.value = 0f; // Reset progress bar value
        }

        targetProgress = 0f; // Reset target progress
        isPaused = false; // Ensure the bar is not paused

        // Re-enable the spawner if it exists
        if (Spawner != null)
        {
            Spawner.SetActive(true);
        }

        // Add initial progress to restart the bar
        IncrementProgress(1f);
        Debug.Log("Progress bar has been reset!");
    }
}