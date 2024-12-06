using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ProgressBar : MonoBehaviour
{
    private Slider progressBar; 
    public float fillSpeed = 0.008f; //Controls the speed of the bar 0.04 works great. Sped up for testing. 
    private float targetProgress = 0; 
    private bool isPaused = false; //Controls when the bar is paused
    public Button Cons_1Button;
    public Button Cons_2Button;
    public static ProgressBar Instance;
    CheckpointBehavior CheckpointBehavior;
    

    public GameObject Spawner;

    private List<float> pausePoints = new List<float> {0.25f, 0.5f, 0.75f, 1f}; //Pause points
    
    private void Awake()
    {
        progressBar = gameObject.GetComponent<Slider>();
        Spawner = GameObject.Find("Spawner");
        CheckpointBehavior = GameObject.Find("ColorController").GetComponent<CheckpointBehavior>();
    }
    
    void Start()
    {
        IncrementProgress(1f); // How much of the slider is filled 
    }

    
    void Update()
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
                        // Perform a different action for the last pause point
                        Debug.Log("Final point reached!");
                        SceneManager.LoadScene("Win Scene"); // Example: Transition to a "Win" scene
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

    // Add progress to the bar
    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBar.value + newProgress;
    }
    
    // Pause the bar
    // Button appears
    public void PauseProgress()
    {
        isPaused = true;
        SceneManager.LoadScene("DANOK");
        //Cons_1Button.gameObject.SetActive(true);
        //Cons_2Button.gameObject.SetActive(true);
        if(Spawner != null)
        {
            Spawner.SetActive(false);
        } 
    }

    // Resume the bar 
    // Then button is pressed, it dissapears
    public void ResumeProgress()
    {
        isPaused = false;

        SceneManager.LoadScene("Runner Game");
        //Cons_1Button.gameObject.SetActive(false);
        //Cons_2Button.gameObject.SetActive(false);

    }
    public void ResetProgressBar()
    {
        // Reset slider value
        if (progressBar != null)
        {
            progressBar.value = 0f; // Reset slider to zero
        }

        // Reset target progress
        targetProgress = 0f;

        // Reset pause state
        isPaused = false;

        // Reset other UI elements (if necessary)
        if (Spawner != null) Spawner.SetActive(true);

        IncrementProgress(1f);
        Debug.Log("Progress bar has been reset!");
    }
}
