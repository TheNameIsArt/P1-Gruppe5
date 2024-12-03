using UnityEngine;
using System.Collections.Generic;

public class ResourceFileNames : MonoBehaviour
{
    // Booleans til at aktivere/deaktivere mapper
    public bool Folder1 = true;
    public bool Folder2 = true;
    public bool Folder3 = false;
    public bool Folder4 = true;

    void Start()
    {
        // Liste over mapper og deres tilsvarende booleans
        Dictionary<string, bool> folders = new Dictionary<string, bool>
        {
            { "Folder1", Folder1 },
            { "Folder2", Folder2 },
            { "Folder3", Folder3 },
            { "Folder4", Folder4 }
        };

        // Samlet liste til alle filnavne
        List<string> allFileNames = new List<string>();

        // Gå gennem mapperne og hent kun aktiverede
        foreach (var folder in folders)
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
        Object[] resources = Resources.LoadAll(folderPath);

        string[] fileNames = new string[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            fileNames[i] = resources[i].name;
        }

        return fileNames;
    }

}