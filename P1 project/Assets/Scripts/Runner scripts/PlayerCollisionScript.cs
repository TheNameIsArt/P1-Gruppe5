using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    GameObject UI;
    UIScript UIScript;
    AudioSource DamageSound;
    private void Awake()
    {
        UI = GameObject.Find("UI");
        UIScript = UI.GetComponent<UIScript>();
        DamageSound = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            
            UIScript.health = UIScript.health - 1;
            if (UIScript.health >= 0)
            {
                DamageSound.Play();
            }
                if (UIScript.health <= 0 && UIScript.gameIsOver == false)
            {
                UIScript.gameOver();
            }
        }
        if (collision.gameObject.layer == 9)
        {
            SceneManager.LoadScene("DANOK");

        }
    }

}

