using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find ("Player");
        player.GetComponent<LaneMover>().enabled = false;
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
