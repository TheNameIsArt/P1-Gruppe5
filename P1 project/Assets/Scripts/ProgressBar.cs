using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    private Slider progressBar; 
    private float fillSpeed = 0.04f; //Controls the speed of the bar 
    private float targetProgress = 0; 

    private void Awake()
    {
        progressBar = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(1f); // How much of the slider is filled 
    }

    // Update is called once per frame
    void Update()
    {
        if (progressBar.value < targetProgress)
        progressBar.value += fillSpeed * Time.deltaTime;
    }

    // Add progress to the bar
    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBar.value + newProgress;
    }
}
