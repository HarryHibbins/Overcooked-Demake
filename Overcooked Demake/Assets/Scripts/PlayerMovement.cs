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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();

        speed = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        horiztonal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horiztonal != 0)
        {
            vertical = 0;
        }
        if (vertical != 0)
        {
            horiztonal = 0;
        }

        rb.velocity = new Vector2(horiztonal, vertical) * speed;


    }
}
