using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{


    public bool holdingItem;

    public FoodTypes.item CurrentItem;
    
    private GameObject hand;
    private bool colourChanged;

    

    private SpriteRenderer renderer;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentItem = FoodTypes.item.NONE;
        holdingItem = false;
        hand = GameObject.FindGameObjectWithTag("Hand");
        renderer = hand.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pickUp()
    {
        if (CurrentItem == FoodTypes.item.LETTUCE )
        {
            renderer.color = new Color(0f, 255f, 0f, 1f); 

        }
        else if (CurrentItem == FoodTypes.item.TOMATO)
        {
            renderer.color = new Color(255f, 0f, 0f, 1f); 
        }
        Debug.Log("pick up");



        holdingItem = true;
    }

    public void place()
    {
        if (CurrentItem != FoodTypes.item.NONE)
        {
            /*if(Input.GetButtonDown("Interact"))
            {*/
            CurrentItem = FoodTypes.item.NONE;
            renderer.color = new Color(255f, 255f, 255f, 1f);
            holdingItem = false;
            Debug.Log("place");


            //}
        }


    }


}
