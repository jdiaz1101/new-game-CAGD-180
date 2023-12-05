using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Remstedt, Reed
// 12/1/2023

public class ZombieScript : MonoBehaviour
{
    private int health = 100;
    public Material Zombie;
    public Material ZombieHurt;
    public PlayerController pController;
 

    // Start is called before the first frame update
    void Start()
    {
       GetComponent<MeshRenderer>().material = Zombie;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //StartCoroutine(Death());
            EnemyDeath();
            pController.totalPoints += 10;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SwordSwingHitBox")
        {
            Debug.Log("colided with swing hit box");
            health += -50;
            StartCoroutine(IsHurt());
            
        }
        if (other.gameObject.tag == "StabHitBox")
        {
            Debug.Log("colided with stab hit box");
            health += -33;
            StartCoroutine(IsHurt());

        }
    }

    IEnumerator IsHurt()

    {

        GetComponent<MeshRenderer>().material = ZombieHurt;
            yield return new WaitForSeconds(0.3f);
        GetComponent<MeshRenderer>().material = Zombie;
    }


    /*
    IEnumerator Death()

    {

        GetComponent<MeshRenderer>().material = ZombieHurt;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);

       
    }
    */
    private void EnemyDeath()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
