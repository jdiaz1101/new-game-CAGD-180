using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;

    public bool shootStraight;

    public bool goingStraight;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (shootStraight)
        {
            transform.position += Vector3.forward* speed * Time.deltaTime;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    

    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }


}
