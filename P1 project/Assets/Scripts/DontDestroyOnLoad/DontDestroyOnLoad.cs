using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad _instance;

    public static DontDestroyOnLoad Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Instance of DontDestroyOnLoadSingleton is null, make sure it is assigned in the scene!");
            }
            return _instance;
        }
    }

    void Awake()
    {
        // Ensure only one instance exists
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);  // This will preserve the GameObject across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicates if they exist
        }
    }
}