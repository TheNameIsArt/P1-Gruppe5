using UnityEngine;
using UnityEngine.UI;

public class UICanvasScript : MonoBehaviour
{
    // Reference to the Canvas component
    public Canvas canvas;

    void Start()
    {
        if (canvas == null)
        {
            // If canvas is not assigned, try to get it from the current GameObject
            canvas = GetComponent<Canvas>();
        }

        // Find the main camera in the scene
        Camera mainCamera = Camera.main;

        if (mainCamera != null && canvas != null)
        {
            // Set the Canvas to use the Main Camera as the Render Camera
            canvas.worldCamera = mainCamera;
            Debug.Log("Main Camera set as Canvas render camera.");
        }
        else
        {
            Debug.LogError("Main Camera or Canvas not found.");
        }
    }
}