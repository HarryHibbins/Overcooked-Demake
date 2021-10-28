using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    public GameObject itemPlaceholder;
    public GameObject equippedItem;

    private GameObject player;
    private bool inBox;
 
    private GameObject WorktopItem;

    public Sprite ChoppedSprite;
    public Sprite UnchoppedSprite;


    public FoodTypes.item ItemOnWorktop;
    
    private PlayerInteractables playerInteractables;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ItemOnWorktop = FoodTypes.item.NONE;
        PlayerInventory = player.GetComponent<PlayerInventory>();

        foreach (Transform child in transform)
        {
            if (child.tag == "WT Item")
            {
                WorktopItem = child.gameObject;
            }
        }
        playerInteractables = player.GetComponent<PlayerInteractables>();
    }

    void Update()
    {
        // if player presses space when nothing is on the board
        if (inBox &&playerInteractables.canUseWT && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem && ItemOnWorktop == FoodTypes.item.NONE)
        {
            PlaceOnWorktop();
        }
        // if player presses space when something is on the board and nothing is in the players hand
        else if (inBox && playerInteractables.canUseWT && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem &&
                 ItemOnWorktop != FoodTypes.item.NONE)
        {
            Debug.Log("test");
            PlayerInventory.CurrentItem = ItemOnWorktop;
            PlayerInventory.holdingItem = true;
            PlayerInventory.UpdateHand();
            clearWorktop();
        }
    }
    
    private void PlaceOnWorktop()
    {
        equippedItem = PlayerInventory.handPlaceholder.transform.GetChild(0).gameObject;
        equippedItem.transform.SetParent(itemPlaceholder.gameObject.transform);
        equippedItem.transform.localPosition = new Vector3(0, 0, -2);

        switch (PlayerInventory.CurrentItem)
        {
            case (FoodTypes.item.LETTUCE):
                ItemOnWorktop = FoodTypes.item.LETTUCE;
                break;

            case (FoodTypes.item.CHOPPED_LETTUCE):
                ItemOnWorktop = FoodTypes.item.CHOPPED_LETTUCE;
                break;

            case (FoodTypes.item.TOMATO):
                ItemOnWorktop = FoodTypes.item.TOMATO;
                break;

            case (FoodTypes.item.CHOPPED_TOMATO):
                ItemOnWorktop = FoodTypes.item.CHOPPED_TOMATO;
                break;

            case (FoodTypes.item.PLATE):
                ItemOnWorktop = FoodTypes.item.PLATE;
                break;

        }
        PlayerInventory.place();
        PlayerInventory.CurrentItem = FoodTypes.item.NONE;
        PlayerInventory.UpdateHand();
    }

    public void clearWorktop()
    {
        foreach (Transform child in itemPlaceholder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ItemOnWorktop = FoodTypes.item.NONE;
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
