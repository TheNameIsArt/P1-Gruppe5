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
            
        }

    }

    void spawnObstacle()
    {
        int laneNumber = Random.Range(0, 6);
        int Xvalue;
        if (laneNumber == 0)
        {
            Xvalue = 3;
        }
        else if (laneNumber == 1)
        {
            Xvalue = 0;
        }
        else if (laneNumber == 2)
        {
            Xvalue = -3;
        }
        else if (laneNumber == 3)
        {
            Xvalue = 3;
            Instantiate(Obstacle, new Vector3(Xvalue, transform.position.y, 0), transform.rotation);
            Xvalue = 0;
        }
        else if (laneNumber == 4)
        {
            Xvalue = 3;
            Instantiate(Obstacle, new Vector3(Xvalue, transform.position.y, 0), transform.rotation);
            Xvalue = -3;
        }
        else if (laneNumber == 5)
        {
            Xvalue = -3;
            Instantiate(Obstacle, new Vector3(Xvalue, transform.position.y, 0), transform.rotation);
            Xvalue = 0;
        }
        else
        {
            Xvalue = 0;
        }
        Instantiate(Obstacle, new Vector3(Xvalue, transform.position.y, 0), transform.rotation);
    }


}
