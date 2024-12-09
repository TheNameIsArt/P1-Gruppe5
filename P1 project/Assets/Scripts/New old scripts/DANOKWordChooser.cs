using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Linq;
using System.Collections.Generic;


public class DANOKWordChooser : MonoBehaviour
{
    //Array of DanokWords
    public string[] DanokWords;

    //Array of possible Consonants
    string[] Consonants = {"B", "D", "F", "G",
        "K", "L", "M", "N", "P", "S", "T", "V"};

    
    public GameObject VoicePlayer;
    public VoiceChooser VoiceChooser;
    public AudioSource AudioSource;
    public AudioClip[] audioClips;

    public bool M1;
    public bool M2;
    public bool F1;
    public bool F2;

    Dictionary<string, AudioClip> avaliableClips;
 
    private void Start()
    {
        VoicePlayer = GameObject.Find("VoicePlayer");
        VoiceChooser = VoicePlayer.GetComponent<VoiceChooser>();


        Dictionary<string, bool> voices = new Dictionary<string, bool>
        {
            { "M1", M1 },
            { "M2", M2 },
            { "F1", F1 },
            { "F2", F2 }
        };

        // Samlet liste til alle filnavne
        List<string> allFileNames = new List<string>();

        // Gå gennem mapperne og hent kun aktiverede
        foreach (var folder in voices)
        {
            if (folder.Value) // Kun inkluder, hvis boolean er true
            {
                string[] fileNames = GetResourceFileNames(folder.Key);
                allFileNames.AddRange(fileNames);
            }
        }

        // Output alle filnavne
        foreach (string name in allFileNames)
        {
            Debug.Log(name);
        }


        
    }


    // Metode til at hente filnavne fra en mappe i Resources
    string[] GetResourceFileNames(string folderPath)
    {
        string trueFolderPath = "Audio/" + folderPath;
        Object[] resources = Resources.LoadAll(trueFolderPath);


        string[] fileNames = new string[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            fileNames[i] = resources[i].name;
        }
        avaliableClips =  new Dictionary<string, AudioClip>();
        return fileNames;
    }

    public void FileLoader()
    {
        
        
        
        DanokWords = new string[VoiceChooser.audioClips.Length];
        
        for (int i = 0; i < VoiceChooser.audioClips.Length; i++)
        {
            // Få navnet på lydklippet
            DanokWords[i] = VoiceChooser.audioClips[i].name;
        }
        Debug.LogFormat("Avaliable consonants: {0} " +
            "Avaliable words: {1}", Consonants.Length, DanokWords.Length);
    }
 
}
