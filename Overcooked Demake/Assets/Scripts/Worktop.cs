using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    private GameObject player;
    private bool inBox;
    private GameObject WorktopItem;
    private SpriteRenderer workTopItemRenderer;

    public Sprite ChoppedSprite;

    public FoodTypes.item ItemOnWorktop;



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

        workTopItemRenderer = WorktopItem.GetComponent<SpriteRenderer>();
        workTopItemRenderer.color = new Color(0f, 0f, 0f, 0f);


    }

    void Update()
    {
        // if player presses space when nothing is on the board
        if (inBox && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem && ItemOnWorktop == FoodTypes.item.NONE)
        {
            PlaceOnWorktop();
            PlayerInventory.place();
        }
        // if player presses space when something is on the board and nothing is in the players hand
        else if (inBox && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem &&
                 ItemOnWorktop != FoodTypes.item.NONE)
        {

            PlayerInventory.CurrentItem = ItemOnWorktop;
            ItemOnWorktop = FoodTypes.item.NONE;
            workTopItemRenderer.color = new Color(0, 0, 0f, 0f);
            PlayerInventory.pickUp();


        }
    }

    private void PlaceOnWorktop()
    {
        if (PlayerInventory.CurrentItem == FoodTypes.item.LETTUCE)
        {
            ItemOnWorktop = FoodTypes.item.LETTUCE;
            workTopItemRenderer.color = new Color(0f, 255f, 0f, 1f);

        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.TOMATO)
        {
            ItemOnWorktop = FoodTypes.item.TOMATO;
            workTopItemRenderer.color = new Color(255f, 0, 0f, 1f);

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
