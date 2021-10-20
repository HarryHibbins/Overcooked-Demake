using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour
{
    private GameObject player;
    private bool inBox;



    public PlayerInventory PlayerInventory;

    public FoodTypes.item Item;

    // public FoodTypes currentFoodType;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //FoodTypes currentFoodType = FoodTypes.NONE;



    }

    // Update is called once per frame
    void Update()
    {
        if (inBox && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem)
        {
            if (Item == FoodTypes.item.LETTUCE)
            {
                PlayerInventory.CurrentItem = FoodTypes.item.LETTUCE;

            }
            else if (Item == FoodTypes.item.TOMATO)
            {
                PlayerInventory.CurrentItem = FoodTypes.item.TOMATO;

            }
            PlayerInventory.UpdateHand();
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform == player.transform)
        {
            inBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform == player.transform)
        {
            inBox = false;
        }
    }
}
