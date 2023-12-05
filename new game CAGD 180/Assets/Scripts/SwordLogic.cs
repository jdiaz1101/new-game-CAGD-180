using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Remstedt, Reed
// 12/5/2023
// Handles sword visibiliy and attack timing

public class SwordLogic : MonoBehaviour
{

    public Vector3 playerPos;
    public GameObject player;

    public GameObject SwordSwingHitBox;
    public GameObject StabHitBox;
    public bool AttackReady = true;




    // Start is called before the first frame update
    void Start()
    {
        SwordSwingHitBox.SetActive(false);
        StabHitBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            if (AttackReady)
            {
                StartCoroutine(StabAttack());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (AttackReady)
            {
                StartCoroutine(SwingAttack());
            }
        }
    }

    IEnumerator StabAttack()
    {
        AttackReady = false;
        StabHitBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        StabHitBox.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        AttackReady = true;
    }
    IEnumerator SwingAttack()
    {
        AttackReady = false;
        yield return new WaitForSeconds(0.1f);
        SwordSwingHitBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        SwordSwingHitBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        AttackReady = true;
    }


}
