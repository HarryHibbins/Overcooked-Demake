using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    private GameObject player;
    private GameObject CBItem;
    private SpriteRenderer CBItemRenderer;
    private bool inBox;

    public Sprite LettuceSprite;
    public Sprite LettuceChoppedSprite;
    public Sprite TomatoSprite;
    public Sprite TomatoChoppedSprite;
    public Sprite empty;

    public FoodTypes.item ItemOnBoard;

    private bool spacePressed;
    private bool choppingComplete;
    [SerializeField] private int chopCount;
    [SerializeField] private int chopTarget = 10;

    private PlayerInteractables playerInteractables;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory = player.GetComponent<PlayerInventory>();
        ItemOnBoard = FoodTypes.item.NONE;

        foreach (Transform child in transform)
        {
            if (child.tag == "CB Item")
            {
                CBItem = child.gameObject;
            }
        }

        CBItemRenderer = CBItem.GetComponent<SpriteRenderer>();
        //LettuceChoppedSprite = CBItemRenderer.sprite;
        //TomatoChoppedSprite = CBItemRenderer.sprite;
        CBItemRenderer.color = new Color(0f, 0f, 0f, 0f);
        playerInteractables = player.GetComponent<PlayerInteractables>();
    }

    void Update()
    {
        // if player presses space when nothing is on the board
        if (inBox && playerInteractables.canUseCB && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem && ItemOnBoard == FoodTypes.item.NONE &&
            FoodTypes.IsCompatible(FoodTypes.station.CHOPPING_BOARD, PlayerInventory.CurrentItem)) 
        {
            PlaceOnBoard();
            PlayerInventory.place();
        }
        // if player presses space when something is on the board and nothing is in the players hand
        else if (inBox && playerInteractables.canUseCB && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem &&
                 (ItemOnBoard == FoodTypes.item.LETTUCE || ItemOnBoard == FoodTypes.item.TOMATO))
        {
            Chop();
            Debug.Log("Chop");
        }
        //Picking up chopped item off the board
        else if (inBox && playerInteractables.canUseCB && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem &&
                 (ItemOnBoard == FoodTypes.item.CHOPPED_LETTUCE || ItemOnBoard == FoodTypes.item.CHOPPED_TOMATO))
        {
            PlayerInventory.CurrentItem = ItemOnBoard;
            PlayerInventory.UpdateHand();

            ClearBoard();


            Debug.Log("pick up");
        }
    }

    void ClearBoard()
    {
        ItemOnBoard = FoodTypes.item.NONE;
        CBItemRenderer.sprite = empty;
        CBItemRenderer.color = new Color(0f, 0f, 0f, 0f);
        chopCount = 0;

    }

    private void PlaceOnBoard()
    {
        if (PlayerInventory.CurrentItem == FoodTypes.item.LETTUCE)
        {
            ItemOnBoard = FoodTypes.item.LETTUCE;
            CBItemRenderer.sprite = LettuceSprite;
            CBItemRenderer.color = new Color(255f, 255f, 255f, 1f); 

        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.TOMATO)
        {
            ItemOnBoard = FoodTypes.item.TOMATO;
            CBItemRenderer.sprite = TomatoSprite;
            CBItemRenderer.color = new Color(255f, 255f, 255f, 1f);

        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.CHOPPED_LETTUCE)
        {
            ItemOnBoard = FoodTypes.item.CHOPPED_LETTUCE;
            CBItemRenderer.sprite = LettuceChoppedSprite;
            CBItemRenderer.color = new Color(255f, 255f, 255f, 1f); 

        }
        else if (PlayerInventory.CurrentItem == FoodTypes.item.CHOPPED_TOMATO)
        {
            ItemOnBoard = FoodTypes.item.CHOPPED_TOMATO;
            CBItemRenderer.sprite = TomatoChoppedSprite;
            CBItemRenderer.color = new Color(255f, 255f, 255f, 1f);

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
            
            if (ItemOnBoard == FoodTypes.item.LETTUCE)
            {
                ItemOnBoard = FoodTypes.item.CHOPPED_LETTUCE;
                CBItemRenderer.sprite = LettuceChoppedSprite;
            }
            else if (ItemOnBoard == FoodTypes.item.TOMATO)
            {
                ItemOnBoard = FoodTypes.item.CHOPPED_TOMATO;
                CBItemRenderer.sprite = TomatoChoppedSprite;
            }
            


            Debug.Log("item chopped");
            choppingComplete = false;
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
