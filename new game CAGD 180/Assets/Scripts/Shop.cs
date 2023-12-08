using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shop : MonoBehaviour
{

    public PlayerController pController;
    private GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.Find("Shop Panel");
        shop.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            shop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            shop.SetActive(false);
        }
    }

}
