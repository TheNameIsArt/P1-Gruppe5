using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    // Array to store different obstacle types
    public GameObject[] Obstacles;

    public float spawnRate;
    public float timer = 0;

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

        // Define positions based on laneNumber
        if (laneNumber == 0)
        {
            Yvalue = -5f;
            Zvalue = 0f; // Closer to the camera
        }
        else if (laneNumber == 1)
        {
            Yvalue = -3.3f;
            Zvalue = 1f;
        }
        else if (laneNumber == 2)
        {
            Yvalue = -1.6f;
            Zvalue = 2f; // Farther away
        }
        else if (laneNumber == 3)
        {
            InstantiateRandomObstacle(new Vector3(transform.position.x, -5f, 0f));
            InstantiateRandomObstacle(new Vector3(transform.position.x, -3.3f, 1f));
            return; // Avoid double-instantiating
        }
        else if (laneNumber == 4)
        {
            InstantiateRandomObstacle(new Vector3(transform.position.x, -5f, 0f));
            InstantiateRandomObstacle(new Vector3(transform.position.x, -1.6f, 2f));
            return; // Avoid double-instantiating
        }
        else if (laneNumber == 5)
        {
            InstantiateRandomObstacle(new Vector3(transform.position.x, -1.6f, 2f));
            InstantiateRandomObstacle(new Vector3(transform.position.x, -3.34f, 1f));
            return; // Avoid double-instantiating
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
}