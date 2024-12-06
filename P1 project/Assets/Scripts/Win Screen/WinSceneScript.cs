using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public UIScript UIScript;
    public TMP_Text CorrectAnswersTxt;
    public TMP_Text WrongAnswersTxt;
    public TMP_Text GoldTxt;
   
    void Start()
    {
        UIScript = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        UIScript.WinScene();
        CorrectAnswersTxt.text = "Du fik " + UIScript.correctAnswersGotten + "/3 ord korrekte";
        WrongAnswersTxt.text = "og\r\n" + UIScript.incorrectAnswersGotten + "/3 forkerte.";
        GoldTxt.text = "du har nu: " + UIScript.Gold + " guld";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
