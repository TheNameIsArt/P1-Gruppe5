using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject Obstacle;
    public float spawnRate;
    public float timer = 0;



    public float heightOffset = 0;

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
            
            //makes game harder after each spawn.
            //spawnRate = spawnRate -0.01f;
            
        }

    }

    void spawnObstacle()
    {
        int laneNumber = Random.Range(0, 6);
        int Yvalue;

        if (laneNumber == 0)
        {
            Yvalue = 3;
        }
        else if (laneNumber == 1)
        {
            Yvalue = 0;
        }
        else if (laneNumber == 2)
        {
            Yvalue = -3;
        }
        else if (laneNumber == 3)
        {
            Yvalue = 3;
            Instantiate(Obstacle, new Vector3(transform.position.x, Yvalue, 0), transform.rotation);
            Yvalue = 0;
        }
        else if (laneNumber == 4)
        {
            Yvalue = 3;
            Instantiate(Obstacle, new Vector3(transform.position.x, Yvalue, 0), transform.rotation);
            Yvalue = -3;
        }
        else if (laneNumber == 5)
        {
            Yvalue = -3;
            Instantiate(Obstacle, new Vector3(transform.position.x, Yvalue, 0), transform.rotation);
            Yvalue = 0;
        }
        else
        {
            Yvalue = 0;
        }
        //Spawns obstacle
        Instantiate(Obstacle, new Vector3(transform.position.x, Yvalue, 0), transform.rotation);
    }


}
