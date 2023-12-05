using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        NewWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewWave()
    {
        Instantiate(zombie, transform.position, transform.rotation);
    }
}
