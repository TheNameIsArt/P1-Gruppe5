using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main menu");
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    // Static variable to store the level index
    public static int nextLevelIndex;
    public void LoadMap()
    {
        // Define the next level index, you can calculate this dynamically
        nextLevelIndex = 1; // Example: Set to the next level index manually or dynamically

        // Load the World Map scene
        SceneManager.LoadScene("World Map");
    }
}