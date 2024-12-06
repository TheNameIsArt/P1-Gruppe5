using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject [] hearts;
    public bool gameIsOver;
    public int health = 3;
   
    public TMP_Text Lives;
    public TMP_Text GoldTxt;
    public GameObject GameOverSceen;
    ProgressBar ProgressBar;
    CheckpointBehavior CheckpointBehavior;
    public GameObject ProgressBarObject;
    public GameObject Hearts;

    public int correctAnswersGotten;
    public int incorrectAnswersGotten;
    public int Gold;
    

    // Start is called before the first frame update
    void Start()
    {
        ProgressBar = GameObject.Find("Progress Bar").GetComponent<ProgressBar>();
        UpdateHearts();
        
    }
   
    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
        UpdateGold();
    }

    void LateUpdate()
    {
        if (gameIsOver == false)
        {
            Lives.text = "Lives: " + health;
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
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

    public void LoseHealth()
    {
        if (health > 0)
        {
            health--;
            UpdateHearts();

            if (health <= 0)
            {
                gameOver();
            }
        }
    }



    public void gameOver()
    {
        gameIsOver = true;
        Lives.text = "Lives: 0";
        GameOverSceen.SetActive(true);
        Time.timeScale = 0;
        
    }
   
    public void ResetLevel()
    {
        Time.timeScale = 1;
        gameIsOver = false;
        health = 3;
        
        GameOverSceen.SetActive(false);
        ProgressBar.ResetProgressBar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        
        
    }
   
    void Pausebutton() 
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else 
        { 
            Time.timeScale = 1;
        }
    }

    public void WinScene()
    {
        ProgressBarObject.SetActive(false);
        Hearts.SetActive(false);
    }

    void UpdateGold()
    {
        GoldTxt.text = "Guld: " + Gold;
    }
}
