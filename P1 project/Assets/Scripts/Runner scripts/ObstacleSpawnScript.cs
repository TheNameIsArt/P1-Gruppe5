using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    // Array to store different obstacle prefabs
    public GameObject[] Obstacles;

    // Reference to the chest prefab
    public GameObject chest;

    // Time interval between obstacle spawns
    public float spawnRate;

    // Timer to track time elapsed since the last spawn
    public float timer = 0;

    // Vertical positions (Y values) for the three lanes
    private float yValueLane1 = -5f; // Lane 1
    private float yValueLane2 = -3.3f; // Lane 2
    private float yValueLane3 = -1.6f; // Lane 3

    void Start()
    {
        // Spawn an initial obstacle when the game starts
        spawnObstacle();
    }

    void Update()
    {
        // Increment the timer with the elapsed time
        if (timer < spawnRate)
        {
            timer += Time.deltaTime; // Add the time elapsed since the last frame
        }
        else
        {
            // Reset the timer and spawn a new obstacle
            timer = 0;
            spawnObstacle();
        }
    }

    // Method to spawn obstacles based on random lane selection
    void spawnObstacle()
    {
        // Randomly choose a lane or multiple lanes for the obstacle
        int laneNumber = Random.Range(0, 6);
        float Yvalue = 0f; // Y position of the obstacle
        float Zvalue = 0f; // Z position of the obstacle

        // Decide the spawn position and behavior based on laneNumber
        switch (laneNumber)
        {
            case 0: // Single obstacle in Lane 1
                Yvalue = yValueLane1;
                Zvalue = 0f; // Closest lane to the camera
                break;

            case 1: // Single obstacle in Lane 2
                Yvalue = yValueLane2;
                Zvalue = 1f;
                break;

            case 2: // Single obstacle in Lane 3
                Yvalue = yValueLane3;
                Zvalue = 2f; // Farthest lane from the camera
                break;

            case 3: // Obstacles in Lane 1 and Lane 2
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane1, 0f));
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane2, 1f));
                return; // Exit to prevent additional instantiation

            case 4: // Obstacles in Lane 1 and Lane 3
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane1, 0f));
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane3, 2f));
                return; // Exit to prevent additional instantiation

            case 5: // Obstacles in Lane 2 and Lane 3
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane3, 2f));
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane2, 1f));
                return; // Exit to prevent additional instantiation

            default:
                // Handle unexpected lane numbers
                Debug.LogError("Unexpected laneNumber value: " + laneNumber);
                return;
        }

        // Spawn a single obstacle at the chosen lane
        InstantiateRandomObstacle(new Vector3(transform.position.x, Yvalue, Zvalue));
    }

    // Helper method to instantiate a random obstacle
    void InstantiateRandomObstacle(Vector3 position)
    {
        // Pick a random obstacle from the array
        int randomIndex = Random.Range(0, Obstacles.Length);
        GameObject selectedObstacle = Obstacles[randomIndex];

        // Instantiate the selected obstacle at the specified position
        Instantiate(selectedObstacle, position, transform.rotation);
    }

    // Method to spawn a chest in Lane 2
    public void ChestSpawner()
    {
        // Instantiate the chest in Lane 2's position
        Instantiate(chest, new Vector3(transform.position.x, yValueLane2, transform.position.z), transform.rotation);
    }
}