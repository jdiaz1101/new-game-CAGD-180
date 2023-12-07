using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{

    public GameObject impactEffect;

    public int damage = 0;

    
    public float knockbackForce = 0f;

    public ZombieScript enemy;

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));

        if (collision.gameObject.tag == "Enemy")
        {
            ZombieScript target = collision.transform.gameObject.GetComponent<ZombieScript>();
            target.ApplyDamage(damage);

            Knockback();

            Debug.Log("Arrow Hit");
        }

        Destroy(gameObject, 5f);

    }

    void Knockback()
    {
        enemy.transform.position += transform.forward * Time.deltaTime * knockbackForce;
    }



}
