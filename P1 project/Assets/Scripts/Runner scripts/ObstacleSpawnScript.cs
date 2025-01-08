using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    // Array to store different obstacle types
    public GameObject[] Obstacles;
    public GameObject chest;

    public float spawnRate;
    public float timer = 0;
    private float yValueLane1 = -5f;
    private float yValueLane2 = -3.3f;
    private float yValueLane3 = -1.6f;

    void Start()
    {
        spawnObstacle();
    }

    void Update()
    {
        // Check if it's time to spawn a new obstacle
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnObstacle();
        }
    }

    void spawnObstacle()
    {
        int laneNumber = Random.Range(0, 6);
        float Yvalue = 0f;
        float Zvalue = 0f;

        // Define positions based on laneNumber using switch-case
        switch (laneNumber)
        {
            case 0:
                Yvalue = yValueLane1;
                Zvalue = 0f; // Closer to the camera
                break;

            case 1:
                Yvalue = yValueLane2;
                Zvalue = 1f;
                break;

            case 2:
                Yvalue = yValueLane3;
                Zvalue = 2f; // Farther away
                break;

            case 3:
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane1, 0f));
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane2, 1f));
                return; // Avoid double-instantiating

            case 4:
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane1, 0f));
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane3, 2f));
                return; // Avoid double-instantiating

            case 5:
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane3, 2f));
                InstantiateRandomObstacle(new Vector3(transform.position.x, yValueLane2, 1f));
                return; // Avoid double-instantiating

            default:
                // Optional: Handle unexpected values
                Debug.LogError("Unexpected laneNumber value: " + laneNumber);
                return;
        }

        // Spawn obstacle for single lane
        InstantiateRandomObstacle(new Vector3(transform.position.x, Yvalue, Zvalue));
    }

    void InstantiateRandomObstacle(Vector3 position)
    {
        // Randomly pick an obstacle from the array
        int randomIndex = Random.Range(0, Obstacles.Length);
        GameObject selectedObstacle = Obstacles[randomIndex];

        // Spawn the selected obstacle at the given position
        Instantiate(selectedObstacle, position, transform.rotation);
    }

    public void ChestSpawner()
    {
        Instantiate(chest, new Vector3(transform.position.x, yValueLane2, transform.position.z), transform.rotation);
    }
}