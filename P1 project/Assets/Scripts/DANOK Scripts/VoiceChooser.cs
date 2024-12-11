using UnityEngine;
using System.Collections.Generic;

public class VoiceChooserV2 : MonoBehaviour
{
    public AudioSource audioSource;          // Reference to AudioSource component.
    public AudioClip[] audioClips;           // Array of all AudioClips.
    private Dictionary<string, AudioClip> audioClipMap; // Dictionary for quick access to clips by name.

    private string audioClipName;            // Dynamically generated name of the audio clip.
    public GameObject Logic;                 // Reference to the Logic GameObject.
    public WordGeneratorV3 WordGenerator;    // Reference to the WordGeneratorV3 script.
    private string[] Voices = { "_F1", "_F2", "_M1", "_M2" }; // Voice types. Not currently implemented.

    public GameObject ThumbsUp;  // Gameobject for if answered correct.
    public GameObject ThumbsDown; // Gameobject for if answered wrong.

    void Awake()
    {
        // Initialize AudioSource component.
        audioSource = GetComponent<AudioSource>();

        // Find the Logic GameObject and its WordGeneratorV3 component.
        Logic = GameObject.Find("Logic");
        WordGenerator = Logic.GetComponent<WordGeneratorV3>();

        // Load all audio clips from the "Audio/F1" resources folder.
        audioClips = Resources.LoadAll<AudioClip>("Audio/F1");

        // Initialize the dictionary to map audio clip names to AudioClip objects.
        audioClipMap = new Dictionary<string, AudioClip>();
        foreach (var audioClip in audioClips)
        {
            if (!audioClipMap.ContainsKey(audioClip.name))
            {
                audioClipMap.Add(audioClip.name, audioClip);
            }
        }

        // Debug message to confirm loaded audio clips.
        Debug.Log($"Loaded {audioClips.Length} audio clips.");
    }

    // Method to play a randomly selected audio clip.
    public void PlayAudio()
    {
        // Ensure the WordGenerator reference is valid.
        if (WordGenerator == null)
        {
            Debug.LogError("WordGenerator is not assigned.");
            return;
        }

        // Choose a random voice type (currently defaults to F1).
        int randomIndex = Random.Range(0, Voices.Length);
        audioClipName = WordGenerator.ChosenWord + Voices[0]; // Change to Voices[randomIndex] if needed.
        Debug.Log("Generated AudioClipName: " + audioClipName);

        // Attempt to play the audio clip if it exists in the dictionary.
        if (audioClipMap.TryGetValue(audioClipName, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError($"AudioClip with name '{audioClipName}' not found.");
        }
    }

    // Method to replay the current audio clip.
    public void PlaySameAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.LogError("AudioSource or clip is missing!");
        }
    }
}