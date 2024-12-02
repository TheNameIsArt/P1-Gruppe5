using UnityEngine;
using System.Collections.Generic;

public class VoiceChooser : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] audioClips; // Drag and drop the AudioSources in the Inspector
    private Dictionary<string, AudioClip> audioClipMap;

    private string audioClipName;


    public GameObject Logic;
    public DANOKWordChooser DANOKWordChooser;
    string[] Voices = { "_F1", "_F2", "_M1", "_M2" };

   
    public void Getfiles()
    {
        
        AudioSource = GetComponent<AudioSource>();
        Logic = GameObject.Find("Logic");
        DANOKWordChooser = Logic.GetComponent<DANOKWordChooser>();
        audioClips = Resources.LoadAll<AudioClip>("Audio");

        // Initialize the dictionary
        audioClipMap = new Dictionary<string, AudioClip>();
        foreach (var audioClip in audioClips)
        {
            if (!audioClipMap.ContainsKey(audioClip.name))
            {
                audioClipMap.Add(audioClip.name, audioClip);
            }
        }
        
    }


    /*public void PlayAudio()
    {
        int randomIndex = Random.Range(0, Voices.Length);
        audioClipName = wordGenerator.ChosenWord + Voices[randomIndex];
        Debug.Log("AudioClipName = " + audioClipName);


        if (audioClipMap.TryGetValue(audioClipName, out AudioClip clip))
        {
            AudioSource.clip = clip;
            AudioSource.Play();
        }
        else
        {
            Debug.LogError($"AudioClip with name '{audioClipName}' not found.");
        }
    }*/
}