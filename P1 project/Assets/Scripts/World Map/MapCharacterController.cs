using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCharacterController : MonoBehaviour
{
    public Transform[] levelPositions; // Positions for each level in the map
    public float moveSpeed = 5f; // Speed of character movement

    private int currentLevelIndex = 0; // Track the current level index
    private bool isMoving = false; // Flag to check if the character is moving

    void Start()
    {
        // Retrieve the level index from the static variable set in the button
        currentLevelIndex = MainButton.nextLevelIndex;

        // Automatically move the character to the next level position
        MoveToNextLevel(currentLevelIndex);
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the character to the selected level
            MoveToLevel();
        }
    }

    // Move the character to the selected level
    public void MoveToNextLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelPositions.Length)
        {
            Debug.LogError("Invalid level index!");
            return;
        }

        currentLevelIndex = levelIndex;
        isMoving = true; // Start moving to the target level position
    }

    // Move the character towards the target position
    void MoveToLevel()
    {
        Vector3 targetPosition = levelPositions[currentLevelIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Once the character reaches the target position, stop moving and start the level
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false; // Stop the movement
            StartLevel(currentLevelIndex); // Trigger the level to start
        }
    }

    // Start the selected level
    void StartLevel(int levelIndex)
    {
        Debug.Log("Starting Level: " + levelIndex);
        SceneManager.LoadScene("Level" + (levelIndex + 1)); // Example of loading levels
    }
}
