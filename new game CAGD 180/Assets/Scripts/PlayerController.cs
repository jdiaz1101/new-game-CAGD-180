using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Camera mainCam;
    private Rigidbody rb;
    public int totalPoints = 0;
    public float health = 10;
    private int healthCost = 10;

    public int maxHealth = 100;

    //public bool canTakeDamage = true;

    private Vector3 startPos;

    public bool invincible = false;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        //if pressing W moves player forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

        }
        //if pressing S moves player back
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        //if the player is pressing A
        if (Input.GetKey(KeyCode.A))
        {
            //the player moves left
            transform.position += Vector3.left * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
            //facingRight = false;
        }
        //if the player is pressing D
        if (Input.GetKey(KeyCode.D))
        {
            //the player moves right
            transform.position += Vector3.right * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            //facingRight = true;
        }

        GameOver();
        
    }




    void FixedUpdate()
    {
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
        }


    }

    private void DamageHP(int value)
    {
        health -= value;
    }

    /*
    private void Respawn()
    {
        GetComponent<Transform>().position = startPos;
        
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //changed to be handled on zombieScript
       /* if (!invincible)
        {
            if (other.gameObject.tag == "Enemy")
            {
                DamageHP(3);
                StartCoroutine(Invincible(2));
                StartCoroutine(Blink());
                Debug.Log("player has taken damage, -10");
                //Respawn();
            }
        }
        */

    }
    public void buyHealth()
    {
        if (totalPoints >= healthCost)
        {
            health = 10;
            totalPoints -= healthCost;
            print("Health purchased. You now have " +health.ToString() + " health and " + totalPoints.ToString() + " points.");
        }
        else
        {
            print("Not enough points");
        }
    }

    private void GameOver()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(4);
            Debug.Log("Game over");
        }
    }

    /*
    IEnumerator Invincible(float secondsToWait)
    {
        invincible = true;
        yield return new WaitForSeconds(secondsToWait);
        invincible = false;
    }
    */

    public IEnumerator Blink()
    {
        for (int index = 0; index < 2; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.5f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }

}
