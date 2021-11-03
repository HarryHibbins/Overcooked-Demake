using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour
{
    private GameObject player;
    private bool inBox;
    private PlayerInteractables playerInteractables;
    public PlayerInventory PlayerInventory;

    public FoodTypes.item Item;

    // public FoodTypes currentFoodType;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory = player.GetComponent<PlayerInventory>();
        playerInteractables = player.GetComponent<PlayerInteractables>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inBox && playerInteractables.canUseStorage && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem)
        {
            Debug.Log("PICKUP");
            switch (Item)
            {
                case FoodTypes.item.LETTUCE:
                    PlayerInventory.CurrentItem = FoodTypes.item.LETTUCE;
                    break;

                case FoodTypes.item.TOMATO:
                    PlayerInventory.CurrentItem = FoodTypes.item.TOMATO;
                    break;

                case FoodTypes.item.PLATE:
                    PlayerInventory.CurrentItem = FoodTypes.item.PLATE;
                    break;

                case FoodTypes.item.BURGER:
                    PlayerInventory.CurrentItem = FoodTypes.item.BURGER;
                    break;

            }
            FindObjectOfType<AudioManager>().Play("Place");
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
