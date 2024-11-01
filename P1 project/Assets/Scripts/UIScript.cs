using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public bool gameIsOver;
    public int health = 3;

    public TMP_Text Lives;
    public GameObject GameOverSceen;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("Lives: {0}", health);
        
    }
    // Update is called once per frame
    void Update()
    {
        Lives.text = "Lives: " + health;
        if (health <= 0 && gameIsOver == false) 
        {
            Debug.Log("Game over!");
        }
    }

    public void gameOver()
    {
        gameIsOver = true;
        Debug.LogFormat("Game Over Man!");
        GameOverSceen.SetActive(true);  
    }

}
