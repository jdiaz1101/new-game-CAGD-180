using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombieInstance;

    public int ZombiesKilled;
    public bool waveReady = true;


    // Start is called before the first frame update
    void Start()
    {
   
        ZombiesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveReady)
        {
            NewWave();
           waveReady = false;
        }
    }

    public void NewWave()
    {
        Instantiate(zombieInstance, transform.position, transform.rotation);
    }
}
