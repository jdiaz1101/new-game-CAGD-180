using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Camera mainCam;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
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
        

    }






    
    void FixedUpdate()
    {
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.yellow);

            transform.LookAt(new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
        }

    }
    

}
