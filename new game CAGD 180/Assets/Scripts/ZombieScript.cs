using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Remstedt, Reed
// 12/5/2023

public class ZombieScript : MonoBehaviour
{
    public GameObject zombiePrefab;

    public int health = 100;
    public int baseHealth = 100;

    public Material Zombie;
    public Material ZombieHurt;
    public PlayerController pController;

    public TMP_Text ZombiesKilledText;
    public ZombieSpawnerScript spawner;

    private Vector3 startPos;
  

    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    float timePassed;
    float newDestinationCD = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        spawner.ZombiesKilled = 0;
       GetComponent<MeshRenderer>().material = Zombie;


        //pController = GameObject.FindWithTag("Player");

        startPos = transform.position;
        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0 )
        {
            spawner.ZombiesKilled += 1;

            pController.totalPoints += 10;
        }


        /*
        if (health <= 0)
        {
            //StartCoroutine(Death());
            spawner.ZombiesKilled += 1;
            //EnemyDeath();
            pController.totalPoints += 10;
            
        }
        if (spawner.ZombiesKilled == 4)
        {
            spawner.waveReady = true;
        }

        */
        /*
        // attempting Zombie Ai
        if (timePassed >= attackCD)
        {
            if (Vector3.Distance(pController.transform.position, transform.position) <= attackRange)
            {
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(pController.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            
        }
        */


        // ZombiesKilledText.text = "ZombiesKilled: " + zombiesKilled.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SwordSwingHitBox")
        {
            Debug.Log("colided with swing hit box");
            health += -50;
            StartCoroutine(IsHurt());
            //EnemyDeath();
            
            EnemyDeath();
            
        }
        if (other.gameObject.tag == "StabHitBox")
        {
            Debug.Log("colided with stab hit box");
            health += -33;
            StartCoroutine(IsHurt());
            //EnemyDeath();
            
            EnemyDeath();
            
        }
        if (other.gameObject.tag == "Arrow")
        {
            
            health -= 25;
            StartCoroutine(IsHurt());
            
            Debug.Log("Arrow hits");
            //EnemyDeath();
            
            EnemyDeath();
            
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
        //canvas.GetComponent<UIManegment>().ZombiesKilledText.ToString(); 
        zombiesKilled += 1;
        

       
    }
    */
    private void EnemyDeath()
    {

        //GetComponent<Transform>().position = startPos;

        if (health <= 0)
        {
            //Destroy(this.gameObject);
            
            transform.position = startPos;

            health = baseHealth;
            Debug.Log("Zombie Health reset");
            pController.totalPoints += 10;



        }
    }

    public void ApplyDamage(int amount)
    {
        health -= amount;

        EnemyDeath();

    }

    

}
