using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript 
{
    public bool gameIsOver;
    public int health = 3;


    public void gameOver()
    {
        gameIsOver = true;
        Debug.LogFormat("Game Over Man!");
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}