using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bow : MonoBehaviour
{

    public GameObject arrowPrefab;

    

    

    private Transform aimTransform;

    public float spawnrate = 1f;
    public float fireRate;
    public float force = 0f;

    public bool shootStraight = false;
    public bool arrowShot = false;
    public bool arrow = false;
    public bool facingStraight = true;

    // Start is called before the first frame update
    void Start()
    {
        //aimTransform = transform.Find("Bow");
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (Input.GetMouseButtonUp(1) && arrowShot == false)
        {

            GameObject arrowHolder;
            arrowHolder = Instantiate(arrowPrefab, transform.position, transform.rotation);

            arrow = true;

            Rigidbody rb;
            rb = arrowHolder.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * force);

            Destroy(arrowHolder, 5.0f); // destroys arrow

            StartCoroutine(FireRate());

        }

        
    }

    private void ArrowActive(bool active)
    {
        arrow = true;
    }

    IEnumerator FireRate()
    {
        arrowShot = true;
        yield return new WaitForSeconds(0.5f);
        arrowShot = false;
    }


}
