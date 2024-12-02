using UnityEngine;

public class RandomAudioSelector : MonoBehaviour
{
    // Reference to the AudioSource component
    private AudioSource audioSource;

    void Start()
    {
        // Get or attach an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Base name and total number of audio clips
        string baseName = "AudioClip_"; // e.g., AudioClip_1, AudioClip_2, ...
        int numberOfClips = 5; // Adjust based on your clip count

        // Randomly select an audio clip
        int randomIndex = Random.Range(1, numberOfClips + 1); // Assuming clips are numbered from 1 to N
        string clipName = $"{baseName}{randomIndex}";

        // Load the AudioClip
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{clipName}");
        if (clip != null)
        {
            // Play the selected audio clip
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log($"Playing audio clip: {clipName}");
        }
        else
        {
            Debug.LogError($"AudioClip {clipName} could not be found in Resources/Audio!");
        }
    }
}