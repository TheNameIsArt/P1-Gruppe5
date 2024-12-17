using UnityEngine;
using UnityEngine.UI;
using TMPro; // Used for TextMeshPro components.

public class WordGeneratorV3 : MonoBehaviour
{

    // Array to store words derived from audio clip names.
    public string[] DanokWords;

    // Array of possible consonants.
    string[] Consonants = {"B", "D", "F", "G",
        "K", "L", "M", "N", "P", "S", "T", "V"};

    // Index to select a consonant from the Consonants array.
    int ConsonantInt;

    // The chosen word from the DanokWords array.
    public string ChosenWord;

    // UI element to display the chosen word.
    public TMP_Text DanokWordTxt;

    // The consonant string associated with the chosen word.
    public string LetterString;

    // GameObject to hold the VoicePlayer object.
    public GameObject VoicePlayer;

    // Script component used to play audio clips.
    public VoiceChooserV2 SpeechScript;

    void Start()
    {
        // Set initial text for the UI element.
        DanokWordTxt.text = "ba?i";

        // Find the VoicePlayer GameObject in the scene.
        VoicePlayer = GameObject.Find("VoicePlayer");

        // Get the VoiceChooserV2 component from the VoicePlayer GameObject.
        SpeechScript = VoicePlayer.GetComponent<VoiceChooserV2>();

        // Initialize the DanokWords array to match the size of the audioClips array.
        DanokWords = new string[SpeechScript.audioClips.Length];

        // Populate the DanokWords array with names derived from audio clips.
        for (int i = 0; i < SpeechScript.audioClips.Length; i++)
        {
            // Get the original name of the audio clip.
            string originalName = SpeechScript.audioClips[i].name;

            // Remove the part of the name after the last underscore "_".
            int underscoreIndex = originalName.LastIndexOf('_');
            if (underscoreIndex >= 0)
            {
                // Keep only the part of the name before the underscore.
                DanokWords[i] = originalName.Substring(0, underscoreIndex);
            }
            else
            {
                // If no underscore is found, use the full name.
                DanokWords[i] = originalName;
            }
        }

        // Call the method to choose a word and perform related actions.
        WordChooser();
    }

    // Method triggered when a button is clicked to choose a word and consonant.
    public void WordChooser()
    {
        // Picks a random index for the consonant.
        ConsonantInt = Random.Range(0, DanokWords.Length - 1);

        // Debug log to display the randomly chosen index.
        Debug.LogFormat("The Random number is: {0}", ConsonantInt);

        // Debug log to display the chosen consonant and word.
        Debug.LogFormat("The Consonant is: {0} and the word is: {1}", Consonants[ConsonantInt], DanokWords[ConsonantInt]);

        // Update the UI text with a placeholder.
        DanokWordTxt.text = "ba?i";

        // Set the chosen word based on the random index.
        ChosenWord = DanokWords[ConsonantInt];

        // Debug log to display the chosen word.
        Debug.LogFormat(ChosenWord);

        // Set the LetterString to the corresponding consonant.
        LetterString = Consonants[ConsonantInt];

        // Debug log to display the LetterString.
        Debug.LogFormat("LetterString = {0}", LetterString);

        // Call the PlayAudio method from the SpeechScript to play the audio.
        SpeechScript.PlayAudio();
    }
}
