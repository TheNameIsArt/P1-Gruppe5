using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardScript : MonoBehaviour
{
    //logik til genkendelse af ord
    public GameObject Logic;
    public WordGeneratorV3 wordGenerator;

    //Referencer og variabler til visning af kode
    public string Letter;
    private TextMeshProUGUI buttonText;
    public TMP_Text WordTxt;

    //Referencer til VoiceChooser scriptet
    public VoiceChooserV2 SpeechScript;
    public GameObject VoicePlayer;

    //Alt til cooldowns på buttons
    private bool isOnCooldown = false;
    private bool isOnCooldownBM = false;
    float cooldownTime = 4f;
    float cooldownTimeBM = 4f;

    //Referencer til SpriteSpawner
    //public SpriteSpawnerScript SpriteSpawnerScript;
    public GameObject SpriteSpawner;
    private void Start()
    {
        //Her referere vi til forskellige gameobjects og scripts, og sætter dem lig med
        //de variabler som vi tidligere lavede
        VoicePlayer = GameObject.Find("VoicePlayer");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooserV2>();
        //SpriteSpawner = GameObject.Find("SpriteSpawner");
        //SpriteSpawnerScript = SpriteSpawner.GetComponent<SpriteSpawnerScript>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGeneratorV3>();


    }
    //script der bruges til størstedelen af alle knapper
    public void TaskOnClick(GameObject button)
    {
        //Her finder vi det ord vi skal gætte fra word generator
        Letter = wordGenerator.LetterString;
        //her sætter vi buttonText lig med det bogstav der står på knappen
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        if (Letter == buttonText.text)
        {
            Debug.Log("Correct answer!");
            ShowThumbsUp(); //Korrekt svar
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
            if (!isOnCooldown)
            {
                /*if (SpriteSpawnerScript.clickCount == 8)
                {
                    SceneManager.LoadScene("TakeSelfieScene");
                }*/
                Invoke("NextWord", 3f);
                //SpriteSpawnerScript.OnButtonClick();
                StartCooldown();
            }
            else
            {
                Debug.Log("Button is on cooldown! Please wait.");
            }
        }
        else
        {
            ShowThumbsDown(); //Forkert svar
            Debug.Log("Wrong! Try again.");
        }

    }


    void NextWord()
    {
        wordGenerator.WordChooser();
    }

    public void Gentag()
    {
        if (SpeechScript != null)
        {
            SpeechScript.PlaySameAudio();
        }
        else
        {
            Debug.LogError("VoiceChooser is null. Cannot play audio!");
        }
    }
    public void BogstavMangler() //Knap til hvis man ikke kan finde konsonanten og vil videre.
    {

        if (!isOnCooldownBM)
        {
            /*if (SpriteSpawnerScript.clickCount == 8)
            {
                SceneManager.LoadScene("TakeSelfieScene");
            }*/
            Debug.Log("BogstavMangler");
            NextWord();
            StartCooldownBM();
            //SpriteSpawnerScript.OnButtonClick();

        }
        else
        {
            Debug.Log("Button is on cooldown! Please wait.");
        }

    }
    private void StartCooldown()
    {
        isOnCooldown = true;
        Invoke("ResetCooldown", cooldownTime);
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
        Debug.Log("Cooldown reset. Button can be pressed again.");
    }
    private void StartCooldownBM()
    {
        isOnCooldownBM = true;
        Invoke("ResetCooldownBM", cooldownTimeBM);
    }

    private void ResetCooldownBM()
    {
        isOnCooldownBM = false;
        Debug.Log("Cooldown MB reset. Button can be pressed again.");
    }
    private void ShowThumbsUp()
    {
        SpeechScript.ThumbsUp.SetActive(true);
        Invoke("HideThumbsUp", 1f);
    }
    private void HideThumbsUp()
    {
        SpeechScript.ThumbsUp.SetActive(false);
    }
    private void ShowThumbsDown()
    {
        SpeechScript.ThumbsDown.SetActive(true);
        Invoke("HideThumbsDown", 1f);
    }
    private void HideThumbsDown()
    {
        SpeechScript.ThumbsDown.SetActive(false);
    }
}

