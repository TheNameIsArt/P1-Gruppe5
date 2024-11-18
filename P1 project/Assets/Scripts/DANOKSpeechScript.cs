using UnityEngine;
using System.Collections.Generic;

public class DANOKSpeechScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public List<AudioClip> audioClips; // Drag and drop the AudioSources in the Inspector
    private Dictionary<string, AudioClip> audioClipMap;

    private string audioClipName;

    public GameObject Logic;
    public WordGenerator wordGenerator;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();

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

 
    public void PlayAudio()
    {
        audioClipName = wordGenerator.DanokWordTxt.text;
        
        if (audioClipMap.TryGetValue(audioClipName, out AudioClip clip))
        {
            AudioSource.clip = clip;
            AudioSource.Play();
        }
        else
        {
            Debug.LogError($"AudioClip with name '{audioClipName}' not found.");
        }
    }
}