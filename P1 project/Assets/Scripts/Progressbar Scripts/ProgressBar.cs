using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ProgressBar : MonoBehaviour
{
    private Slider progressBar; 
    public float fillSpeed = 0.008f; //Controls the speed of the bar 0.04 works great. Sped up for testing. 
    private float targetProgress = 0; 
    private bool isPaused = false; //Controls when the bar is paused
    public Button Cons_1Button;
    public Button Cons_2Button;

    public GameObject Spawner;

    private List<float> pausePoints = new List<float> {0.25f, 0.5f, 0.75f}; //Pause points
    
    private void Awake()
    {
        progressBar = gameObject.GetComponent<Slider>();
        Spawner = GameObject.Find("Spawner");
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
    // Button appears
    public void PauseProgress()
    {
        isPaused = true;
        Cons_1Button.gameObject.SetActive(true);
        Cons_2Button.gameObject.SetActive(true);
        Spawner.SetActive(false);
    }

    // Resume the bar 
    // Then button is pressed, it dissapears
    public void ResumeProgress()
    {
        isPaused = false;
        Cons_1Button.gameObject.SetActive(false);
        Cons_2Button.gameObject.SetActive(false);
        Spawner.SetActive(true);
    }

}
