using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    private Slider progressBar;
    public float fillSpeed = 0.008f; // Controls the speed of the bar 0.04 works great. Sped up for testing.
    private float targetProgress = 0;
    private bool isPaused = false; // Controls when the bar is paused
    public static ProgressBar Instance;
    string currentLevelName;
    CheckpointBehavior CheckpointBehavior;
    ObstacleSpawnScript ObstacleSpawnScript;

    public GameObject Spawner;

    private List<float> pausePoints = new List<float> { 0.25f, 0.5f, 0.75f, 1f }; // Pause points

    private void Awake()
    {
        progressBar = gameObject.GetComponent<Slider>();
        DontDestroyOnLoad(gameObject);

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid errors
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        IncrementProgress(1f); // How much of the slider is filled
    }

    private void Update()
    {
        // Update the progress bar only if not paused
        if (!isPaused && progressBar.value < targetProgress)
        {
            progressBar.value += fillSpeed * Time.deltaTime;

            // Check if we hit a pause point
            foreach (float pausePoint in pausePoints)
            {
                if (progressBar.value >= pausePoint && progressBar.value < pausePoint + fillSpeed * Time.deltaTime)
                {
                    if (pausePoint == pausePoints[pausePoints.Count - 1]) // Check if it's the last pause point
                    {
                        Debug.Log("Final point reached!");
                        SceneManager.LoadScene("Win Scene");
                    }
                    else
                    {
                        PauseProgress();
                    }
                    break;
                }
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinitialize objects specific to the scene
        Spawner = GameObject.Find("Spawner");
        if (Spawner != null)
        {
            ObstacleSpawnScript = Spawner.GetComponent<ObstacleSpawnScript>();
        }
    }

    // Add progress to the bar
    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBar.value + newProgress;
    }

    // Pause the bar
    public void PauseProgress()
    {
        isPaused = true;
        currentLevelName = SceneManager.GetActiveScene().name;
        Debug.Log("Last Level Scene Name: " + currentLevelName);

        if (ObstacleSpawnScript != null)
        {
            ObstacleSpawnScript.ChestSpawner();
        }
        if (Spawner != null)
        {
            Spawner.SetActive(false);
        }
    }

    // Resume the bar
    public void ResumeProgress()
    {
        isPaused = false;

        if (currentLevelName != null)
        {
            SceneManager.LoadScene(currentLevelName);
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void ResetProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.value = 0f;
        }

        targetProgress = 0f;
        isPaused = false;

        if (Spawner != null)
        {
            Spawner.SetActive(true);
        }

        IncrementProgress(1f);
        Debug.Log("Progress bar has been reset!");
    }
}