using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public GameObject arrowPrefab;

   

    public float spawnrate = 1f;
    public float fireRate;

    public bool shootRight = false;
    public bool arrowShot = false;
    public bool arrow = false;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight == true)
            {
                facingRight = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (facingRight == false)
            {
                facingRight = true;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (arrow == true)
            {
                ShootArrow();
            }
        }

    }

    private void ShootArrow()
    {
        GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, transform.rotation);

        arrow = true;

        if (facingRight == true)
        {
            arrowInstance.GetComponent<Arrow>().goingRight = shootRight;
        }
        else
        {
            arrowInstance.GetComponent<Arrow>().goingRight = false;

        }
        StartCoroutine(FireRate());

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
