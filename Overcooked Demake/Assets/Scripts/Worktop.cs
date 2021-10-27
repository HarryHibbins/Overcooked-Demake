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

        workTopItemRenderer = WorktopItem.GetComponent<SpriteRenderer>();
        workTopItemRenderer.color = new Color(0f, 0f, 0f, 0f);
        UnchoppedSprite = workTopItemRenderer.sprite;
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

            PlayerInventory.CurrentItem = ItemOnWorktop;
            ItemOnWorktop = FoodTypes.item.NONE;
            workTopItemRenderer.color = new Color(0, 0, 0f, 0f);
            PlayerInventory.UpdateHand();


        }
    }

    private void PlaceOnWorktop()
    {
        if (PlayerInventory.CurrentItem == FoodTypes.item.LETTUCE)
        {

            ItemOnWorktop = FoodTypes.item.LETTUCE;
            workTopItemRenderer.color = new Color(0f, 255f, 0f, 1f);
            workTopItemRenderer.sprite = UnchoppedSprite;


        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.TOMATO)
        {
            ItemOnWorktop = FoodTypes.item.TOMATO;
            workTopItemRenderer.color = new Color(255f, 0, 0f, 1f);
            workTopItemRenderer.sprite = UnchoppedSprite;


        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.CHOPPED_LETTUCE)
        {
            ItemOnWorktop = FoodTypes.item.CHOPPED_LETTUCE;
            workTopItemRenderer.color = new Color(0f, 255f, 0f, 1f);
            workTopItemRenderer.sprite = ChoppedSprite;

        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.CHOPPED_TOMATO)
        {
            ItemOnWorktop = FoodTypes.item.CHOPPED_TOMATO;
            workTopItemRenderer.color = new Color(255f, 0, 0f, 1f);
            workTopItemRenderer.sprite = ChoppedSprite;
        }
        PlayerInventory.UpdateHand();
        PlayerInventory.place();

        PlayerInventory.CurrentItem = FoodTypes.item.NONE;

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
