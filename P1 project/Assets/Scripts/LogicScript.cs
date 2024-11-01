using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript 
{
    public bool gameIsOver;
    public int health = 3;


    public void gameOver()
    {
        gameIsOver = true;
        Debug.LogFormat("Game Over Man!");
    }
}