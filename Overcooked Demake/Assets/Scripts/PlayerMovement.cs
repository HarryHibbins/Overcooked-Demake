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
    private float rayLength = 0.5f;

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

        Debug.DrawRay(RaycastObject.transform.position, RaycastObject.transform.TransformDirection(Vector3.up) * rayLength, Color.red );



        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            
            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + moveUnits,
                    transform.position.z);

            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);

            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x - moveUnits, transform.position.y ,
                    transform.position.z);
            }

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
            
            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveUnits,
                    transform.position.z);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);
            
            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x + moveUnits, transform.position.y ,
                    transform.position.z); 
            }
        }

        ObjectBlocking = false;


    }

    private void isObjectBlocking()
    {
        RaycastHit2D hit = Physics2D.Raycast(RaycastObject.transform.position,
            RaycastObject.transform.TransformDirection(Vector3.up),
            rayLength, Environemnt);

        if (hit.collider != null)
        {
            Debug.Log("Hit " + hit.collider.name);
            ObjectBlocking = true;
        }
    }
}
