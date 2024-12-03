using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public bool gameIsOver;
    public int health = 3;

    public TMP_Text Lives;
    public GameObject GameOverSceen;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == false)
        {
            Lives.text = "Lives: " + health;
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
}
