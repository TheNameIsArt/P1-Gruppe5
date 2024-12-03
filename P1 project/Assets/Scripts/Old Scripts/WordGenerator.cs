using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using System.Linq;


public class WordGenerator : MonoBehaviour
{
    //Array of DanokWords
    string[] DanokWords;
    
    //Array of possible Consonants
    string[] Consonants = {"B", "D", "F", "G",
        "K", "L", "M", "N", "P", "S", "T", "V"};
   
    
    //Number referenced in the arrays
    int ConsonantInt;
    public string ChosenWord;

    public TMP_Text DanokWordTxt;
    public string LetterString;
    public GameObject VoicePlayer;
    public VoiceChooser SpeechScript;
   

    void Start()
    {
       

        VoicePlayer = GameObject.Find("VoicePlayer");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooser>();

        DanokWords = new string[SpeechScript.audioClips.Length];

        for (int i = 0; i < SpeechScript.audioClips.Length; i++)
        {
            // Få navnet på lydklippet
            string originalName = SpeechScript.audioClips[i].name;

            // Fjern slutningen af navnet (del efter den sidste underscore "_")
            int underscoreIndex = originalName.LastIndexOf('_');
            if (underscoreIndex >= 0)
            {
                DanokWords[i] = originalName.Substring(0, underscoreIndex); // Behold kun delen før "_"
            }
            else
            {
                DanokWords[i] = originalName; // Hvis der ikke er "_", behold hele navnet
            }
        }
       
        WordChooser();
        
    }

    //When the button is clicked 
    public void WordChooser()
    {
        //Picks random Consonant number
        ConsonantInt = Random.Range(0, 7);

        //Says the ConsonantInt
        Debug.LogFormat("The Random number is: {0}", ConsonantInt);

        //Sets the Consonants Array and DanokWords Array to the same as ConsonantInt.
        Debug.LogFormat("The Consonant is: {0} and the word is: {1}", Consonants[ConsonantInt], DanokWords[ConsonantInt]);

        DanokWordTxt.text = "ba?i";
        ChosenWord = DanokWords[ConsonantInt];
        LetterString = Consonants[ConsonantInt];
        Debug.LogFormat("LetterString = {0}", LetterString);
        // Find alle elementer, der indeholder 'n'
        var results = DanokWords.Where(item => item.Contains(LetterString.ToLower())).ToArray();

        if (results.Length > 0)
        {
            Debug.Log("Fundne elementer: " + string.Join(", ", results));
        }
        else
        {
            Debug.Log("Ingen elementer fundet.");
        }

        Debug.LogFormat("Danokwords er: {0} lang", DanokWords.Length);

        //SpeechScript.PlayAudio();
        
        
    }
}
  

  

