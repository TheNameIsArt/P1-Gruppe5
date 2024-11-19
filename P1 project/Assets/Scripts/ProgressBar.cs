using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ProgressBar : MonoBehaviour
{
    private Slider progressBar; 
    private float fillSpeed = 0.04f; //Controls the speed of the bar 
    private float targetProgress = 0; 
    private bool isPaused = false; //Controls when the bar is paused
    public Button Cons_1Button;

    private List<float> pausePoints = new List<float> {0.25f, 0.5f, 0.75f}; //Pause points
    

    private void Awake()
    {
        progressBar = gameObject.GetComponent<Slider>();
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
                    PauseProgress();
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
    public void PauseProgress()
    {
        isPaused = true;
        Cons_1Button.gameObject.SetActive(true);
    }

    // Resume the bar 
    public void ResumeProgress()
    {
        isPaused = false;
        Cons_1Button.gameObject.SetActive(false);
    }

}
