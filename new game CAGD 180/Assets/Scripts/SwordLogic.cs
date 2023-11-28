using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour
{

    public Vector3 playerPos;
    public GameObject player;

    public MeshRenderer SwordSwingHitBox;
    public MeshRenderer StabHitBox;
    public bool AttackReady = true;


    

    // Start is called before the first frame update
    void Start()
    {
        SwordSwingHitBox.enabled = false;
        StabHitBox.enabled = false;
        
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
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
        StabHitBox.enabled = true;
        yield return new WaitForSeconds(0.2f);
        StabHitBox.enabled = false;
        yield return new WaitForSeconds(0.1f);
        AttackReady = true;
    }
    IEnumerator SwingAttack()
    {
        AttackReady = false;
        yield return new WaitForSeconds(0.4f);
        SwordSwingHitBox.enabled = true;
        yield return new WaitForSeconds(0.2f);
        SwordSwingHitBox.enabled = false;
        yield return new WaitForSeconds(0.5f);
        AttackReady = true;
    }
}
