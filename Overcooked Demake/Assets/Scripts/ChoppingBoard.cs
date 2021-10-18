using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    private GameObject player;
    private bool inBox;
    private GameObject CBItem;
    private SpriteRenderer CBItemRenderer;

    public Sprite ChoppedSprite;
    public enum FoodTypes
    {
        LETTUCE,
        TOMATO,
        NONE
    }

    public FoodTypes ItemOnBoard;

    private bool spacePressed;
    private bool choppingComplete;
    [SerializeField] private int chopCount;
    [SerializeField] private int chopTarget = 10;
    
    
    
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ItemOnBoard = FoodTypes.NONE;

        foreach (Transform child in transform)
        {
            if (child.tag == "CB Item")
            {
                CBItem = child.gameObject;
            }
        }

        CBItemRenderer = CBItem.GetComponent<SpriteRenderer>();
        CBItemRenderer.color = new Color(0f, 0f, 0f, 0f);


    }

    void Update()
    {
        // if player presses space when nothing is on the board
        if (inBox && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem && ItemOnBoard == FoodTypes.NONE) 
        {
            PlaceOnBoard();
            PlayerInventory.place();
        }
        // if player presses space when something is on the board and nothing is in the players hand
        else if (inBox && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem &&
                 ItemOnBoard != FoodTypes.NONE)
        {
            Chop();
            Debug.Log("Chop");
        }
    }

    private void PlaceOnBoard()
    {
        if (PlayerInventory.CurrentItem == PlayerInventory.FoodTypes.LETTUCE)
        {
            ItemOnBoard = FoodTypes.LETTUCE;
            CBItemRenderer.color = new Color(0f, 255f, 0f, 1f); 

        }
        else if (PlayerInventory.CurrentItem == PlayerInventory.FoodTypes.TOMATO)
        {
            ItemOnBoard = FoodTypes.TOMATO;
            CBItemRenderer.color = new Color(255f, 0, 0f, 1f);

        }
    }

    private void Chop()
    {
        
        if (!spacePressed && !choppingComplete)
        {
            spacePressed = true;
            chopCount++;
        }

        else if (spacePressed&& !choppingComplete)
        {
            spacePressed = false;
        }
        
        if (chopCount == chopTarget)
        {
            choppingComplete = true;
            CBItemRenderer.sprite = ChoppedSprite;

            Debug.Log("item chopped");
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
