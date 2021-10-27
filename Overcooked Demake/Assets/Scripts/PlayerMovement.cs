using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public float speed;
    private float horiztonal;
    private float vertical;
    public int moveUnits;

    public GameObject RaycastObject;
    public LayerMask Environemnt;
    private bool ObjectBlocking;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();

        speed = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        /*horiztonal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horiztonal != 0)
        {
            vertical = 0;
        }
        if (vertical != 0)
        {
            horiztonal = 0;
        }

        rb.velocity = new Vector2(horiztonal, vertical) * speed;*/

    

        
     

        Debug.DrawRay(RaycastObject.transform.position, RaycastObject.transform.TransformDirection(Vector3.up) , Color.red);
        
      
        RaycastHit2D hit =  Physics2D.Raycast(RaycastObject.transform.position, RaycastObject.transform.TransformDirection(Vector3.up) ,
            1, Environemnt);

        if (hit.collider != null)
        {
            Debug.Log("Hit" + hit.collider.name);
            ObjectBlocking = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + moveUnits,
                    transform.position.z);

                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - moveUnits, transform.position.y ,
                transform.position.z);
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveUnits,
                transform.position.z);
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + moveUnits, transform.position.y ,
                transform.position.z);
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);

        }

        ObjectBlocking = false;


    }

}
