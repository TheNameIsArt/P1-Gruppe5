using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class ButtonScript : MonoBehaviour
{
    

    public GameObject Logic;
    public WordGenerator wordGenerator;
    string Letter;
    public TMP_Text KeyTxt;
    

    void Start()
    {
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();
        
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

        
        if (Letter == KeyTxt.text)
        {
            Debug.Log("Correct answer!");
             wordGenerator.WordChooser();
        }
        else
        {
            Debug.Log("Wrong! Try again.");
        }
    }
}
