using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterBow : MonoBehaviour
{
    public GameObject repeaterBow;

    public float spawnrate = 1f;

    public bool shoot = false;

    public float force = 0f;

    public bool arrowShot = false;
    public bool arrow = false;

    private void Start()
    {
        InvokeRepeating("ShootRepeaterBow", 0, spawnrate);
    }

    private void Update()
    {
        if (arrowShot == false)
        {
            GameObject arrowHolder;
            arrowHolder = Instantiate(repeaterBow, transform.position, transform.rotation);

            arrow = true;

            Rigidbody rb;
            rb = arrowHolder.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * force);

            Destroy(arrowHolder, 5.0f); // destroys arrow


            StartCoroutine(FireRate());
        }
        

    }

    private void ShootRepeaterBow()
    {
        GameObject BulletBillInstance = Instantiate(repeaterBow, transform.position, repeaterBow.transform.rotation);
        repeaterBow.GetComponent<Arrow>().goingStraight = shoot;
    }

    private void ArrowActive(bool active)
    {
        arrow = true;
    }

    IEnumerator FireRate()
    {
        arrowShot = true;
        yield return new WaitForSeconds(2f);
        arrowShot = false;
    }

}
