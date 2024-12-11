using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardScript : MonoBehaviour
{
    //Script used to track if a button with a letter corespons to the correct letter missing in the chosen word from wordGenerator


    // Logic for recognizing words
    public GameObject Logic; // A reference to the GameObject containing the logic for the word-guessing game
    public WordGeneratorV3 wordGenerator; // Reference to the script handling word generation
    bool NoMoreTries = false; // Tracks if the player has no more attempts left

    // References for displaying the code (letters and UI)
    public string Letter; // The correct letter the player is supposed to guess
    private TextMeshProUGUI buttonText; // Reference to the text on a button
    public TMP_Text WordTxt; // UI element to display the word

    // References for voice feedback
    public VoiceChooserV2 SpeechScript; // Handles audio playback
    public GameObject VoicePlayer; // GameObject controlling the audio

    // Other references
    CheckpointBehavior CheckpointBehavior; // Controls behaviors related to checkpoints
    UIScript UIScript; // Manages UI-related actions and data

    // Button cooldown logic
    private bool isOnCooldown = false; // Tracks if buttons are on cooldown
    private bool isOnCooldownBM = false; // Tracks a secondary cooldown for buttons
    float cooldownTime = 4f; // Cooldown time for buttons
    float cooldownTimeBM = 4f; // Cooldown time for secondary buttons

    private ProgressBar progressBar; // Reference to the progress bar

    // Attempts and rewards
    private int triesLeft = 3; // Number of attempts allowed for the player
    public TMP_Text triesText; // UI element showing remaining attempts
    public TMP_Text goldToGainTxt; // UI element displaying potential rewards
    int goldToGain = 20; // Gold reward for guessing correctly
    int goldToGainReset; // Keeps track of the original gold reward

    private void Start()
    {
        // Initialize references to GameObjects and scripts
        VoicePlayer = GameObject.Find("VoicePlayer");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooserV2>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGeneratorV3>();

        // Find the progress bar and checkpoint-related scripts
        progressBar = GameObject.Find("DontDestroyOnLoad").GetComponentInChildren<ProgressBar>();
        CheckpointBehavior = GameObject.Find("ColorController").GetComponent<CheckpointBehavior>();
        UIScript = GameObject.Find("UI").GetComponent<UIScript>();
    }

   
    //Task used on all buttons with letters
    public void TaskOnClick(GameObject button)
    {
        Letter = wordGenerator.LetterString; // Get the correct letter from the word generator
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>(); // Fetch the button's letter text

        if (Letter == buttonText.text) // Correct guess
        {
            Debug.Log("Correct answer!");
            ShowThumbsUp(); // Trigger thumbs-up animation and effects
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord; // Update UI to show the full word
            if (!isOnCooldown)
            {
                StartCooldown(); // Begin cooldown for the button to prevent spamming
            }
            else
            {
                Debug.Log("Button is on cooldown! Please wait.");
            }
        }
        else // Incorrect guess
        {
            ShowThumbsDown(); // Trigger thumbs-down animation and effects
            Debug.Log("Wrong! Try again.");
        }
    }



    //Repeat button functions
    public void Gentag()
    {
        if (SpeechScript != null)
        {
            SpeechScript.PlaySameAudio(); // Replay the current audio clip
        }
        else
        {
            Debug.LogError("VoiceChooser is null. Cannot play audio!");
        }
    }



    private void StartCooldown()
    {
        isOnCooldown = true;
        Invoke("ResetCooldown", cooldownTime); // Automatically reset after cooldownTime seconds
    }

    private void ResetCooldown()
    {
        isOnCooldown = false; // Reset the button state
        Debug.Log("Cooldown reset. Button can be pressed again.");
    }
    /*private void StartCooldownBM()
    {
        isOnCooldownBM = true;
        Invoke("ResetCooldownBM", cooldownTimeBM);
    }

    private void ResetCooldownBM()
    {
        isOnCooldownBM = false;
        Debug.Log("Cooldown MB reset. Button can be pressed again.");
    }*/
    private void ShowThumbsUp()
    {
        SpeechScript.ThumbsUp.SetActive(true); // Show thumbs-up animation
        Invoke("HideThumbsUp", 1f); // Hide after 1 second
        CheckpointBehavior.CorrectButton(); // Update game state for a correct answer
        UIScript.correctAnswersGotten += 1; // Increment correct answers count
        UIScript.Gold += goldToGain; // Add gold reward
        progressBar.ResumeProgress(); // Update progress
    }

    private void HideThumbsUp()
    {
        SpeechScript.ThumbsUp.SetActive(false); // Hides thumbs-up animation
    }
    private void ShowThumbsDown()
    {
        SpeechScript.ThumbsDown.SetActive(true); // Show thumbs-down animation
        triesLeft--; // Decrement remaining tries
        goldToGain /= 2; // Halve the gold reward
        goldToGainTxt.text = "Guld du kan vinde: " + goldToGain; // Updates goldToGainTxt to correct amount of gold
        triesText.text = "Forsøg tilbage: " + triesLeft; // Updates tries left to correct amount of tries

        Invoke("HideThumbsDown", 1f); // Hide after 1 second
        if (triesLeft <= 0 && !NoMoreTries)
        {
            NoMoreTries = true; // Prevent further tries
            CheckpointBehavior.IncorrectButton(); // Trigger incorrect logic
            UIScript.incorrectAnswersGotten += 1; // Increment incorrect answers count
            progressBar.ResumeProgress(); // Update progress
        }
    }

    private void HideThumbsDown()
    {
        SpeechScript.ThumbsDown.SetActive(false); // Hides thumbs-down animation
    }
}

