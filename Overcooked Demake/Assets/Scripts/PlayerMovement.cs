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
    private float rayLength = 0.75f;
    public SpriteRenderer spriteRenderer;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite downSprite;
    public Sprite upSprite;
    public GameObject raycastParent;
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
            raycastParent.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            spriteRenderer.sprite = upSprite;
            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + moveUnits,
                    transform.position.z);

            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            raycastParent.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
            spriteRenderer.sprite = leftSprite;
            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x - moveUnits, transform.position.y ,
                    transform.position.z);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            raycastParent.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
            spriteRenderer.sprite = downSprite;
            isObjectBlocking();

            if (!ObjectBlocking)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveUnits,
                    transform.position.z);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            raycastParent.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);
            spriteRenderer.sprite = rightSprite;
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
