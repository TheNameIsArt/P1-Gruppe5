using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonScript : MonoBehaviour
{
    

    public GameObject Logic;
    public WordGenerator wordGenerator;
    string Letter;
    public TMP_Text KeyTxt;
    public TMP_Text WordTxt;
    AudioSource SFXPlayer;
    bool Freezebutton = false;
    

    void Start()
    {
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();
        SFXPlayer = GetComponent<AudioSource>();
        Letter = wordGenerator.LetterString;

        //Finds button and adds listener to click
        Button Key = GetComponent<Button>();
        Key.onClick.AddListener(TaskOnClick);
    }
    private void Update()
    {
        Letter = wordGenerator.LetterString;

    }
    void TaskOnClick()
    {

        if (Freezebutton == false)
        {
            if (Letter == KeyTxt.text)
            {
                Debug.Log("Correct answer!");
                wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
                SFXPlayer.Play();
                Invoke("NextWord", 5f);
                Freezebutton = true;
            }
            else
            {
                if (Freezebutton == false)
                {
                    Debug.Log("Wrong! Try again.");
                }
            }
        }
        
    }
    void NextWord()
    {
        wordGenerator.WordChooser();
        Freezebutton = false;
    }
}
