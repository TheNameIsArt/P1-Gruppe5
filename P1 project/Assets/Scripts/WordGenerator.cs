using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WordGenerator : MonoBehaviour
{
    //Array of DanokWords
    string[] DanokWords = { "Babi",
        "Badi", "Bafi", "Bagi", "Baki",
        "Bali", "Bami", "Bani", "Bapi",
        "Basi", "Bati", "Bavi"};
    
    //Array of possible Consonants
    string[] Consonants = {"B", "D", "F", "G",
        "K", "L", "M", "N", "P", "S", "T", "V"};
   
    
    //Number referenced in the arrays
    int ConsonantInt;


    public TMP_Text DanokWordTxt;
    public string LetterString;
    public GameObject VoicePlayer;
    public DANOKSpeechScript SpeechScript;

    void Start()
    {
        VoicePlayer = GameObject.Find("VoicePlayer");
        SpeechScript = VoicePlayer.GetComponent<DANOKSpeechScript>();
        WordChooser();
        
    }

    //When the button is clicked 
    public void WordChooser()
    {
        //Picks random number
        ConsonantInt = Random.Range(0, 7);

        //Says the ConsonantInt
        Debug.LogFormat("The Random number is: {0}", ConsonantInt);

        //Sets the Consonants Array and DanokWords Array to the same as ConsonantInt.
        Debug.LogFormat("The Consonant is: {0} and the word is: {1}", Consonants[ConsonantInt], DanokWords[ConsonantInt]);

        DanokWordTxt.text = DanokWords[ConsonantInt];
        LetterString = Consonants[ConsonantInt];
        Debug.LogFormat("LetterString = {0}", LetterString);
        SpeechScript.PlayAudio();
    }
}
  

  

