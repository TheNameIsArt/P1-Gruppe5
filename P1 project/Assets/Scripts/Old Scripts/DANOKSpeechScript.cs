using UnityEngine;
using System.Collections.Generic;

public class DANOKSpeechScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] audioClips; // Drag and drop the AudioSources in the Inspector
    private Dictionary<string, AudioClip> audioClipMap;

    private string audioClipName;

    public GameObject Logic;
    public DANOKWordChooser wordGenerator;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<DANOKWordChooser>();
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

 /*
    public void PlayAudio()
    {
        audioClipName = wordGenerator.ChosenWord;
        
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