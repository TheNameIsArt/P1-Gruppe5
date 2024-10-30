using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject Obstacle;
    public float spawnRate;
    private float timer = 0;

    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnObstacle();
            
        }

    }

    void spawnObstacle()
    {
        float lowestPoint = transform.position.x - heightOffset;
        float highestPoint = transform.position.x + heightOffset;
        Instantiate(Obstacle, new Vector3(Random.Range(lowestPoint,highestPoint),transform.position.y, 0), transform.rotation);
    }


}
