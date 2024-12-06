using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(2);
    }
}