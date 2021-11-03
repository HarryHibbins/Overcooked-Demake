using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grill : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    private GameObject player;

    private PlayerInteractables playerInteractables;
    private bool inBox;

    public FoodTypes.item ItemOnGrill;

    private GameObject GRItem;
    private SpriteRenderer GRItemRenderer;
    public Sprite CookedSprite;
    public Sprite UncookedSprite;
    public float cookTime = 8.0f;
    
    public Slider slider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory = player.GetComponent<PlayerInventory>();
        playerInteractables = player.GetComponent<PlayerInteractables>();
        ItemOnGrill = FoodTypes.item.NONE;

        foreach (Transform child in transform)
        {
            if (child.tag == "GR Item")
            {
                GRItem = child.gameObject;
            }
        }
        GRItemRenderer = GRItem.GetComponent<SpriteRenderer>();
        UncookedSprite = GRItemRenderer.sprite;
        GRItemRenderer.color = new Color(0f, 0f, 0f, 0f);
    }

    
    void Update()
    {
        if (inBox && playerInteractables.canUseGrill && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem && 
            ItemOnGrill == FoodTypes.item.NONE && FoodTypes.IsCompatible(FoodTypes.station.GRILL, PlayerInventory.CurrentItem))
        {
            PlaceOnGrill();
            PlayerInventory.place();
            FindObjectOfType<AudioManager>().Play("PlaceOnGrill");
            StartCoroutine(GrillItem(cookTime, FoodTypes.item.BURGER));
        }
        else if (inBox && playerInteractables.canUseGrill && Input.GetButtonDown("Interact") && !PlayerInventory.holdingItem &&
                 ItemOnGrill == FoodTypes.item.COOKED_BURGER)
        {
            PlayerInventory.CurrentItem = ItemOnGrill;
            PlayerInventory.UpdateHand();
            FindObjectOfType<AudioManager>().Play("PlaceOnGrill");
            ClearGrill();

        }
    }

    void PlaceOnGrill()
    {
        if (PlayerInventory.CurrentItem == FoodTypes.item.BURGER)
        {
            ItemOnGrill = FoodTypes.item.BURGER;
            GRItemRenderer.sprite = UncookedSprite;
            GRItemRenderer.color = new Color32(250, 159, 205, 255);
            
        }
       
    }

    IEnumerator GrillItem(float time, FoodTypes.item food)
    {
        int progress = 0;
        slider.gameObject.SetActive(true);

        while (progress != time)
        {
            yield return new WaitForSeconds(1);
            slider.value++;
            progress ++;
        }

        switch (food)
        {
            case (FoodTypes.item.BURGER):
                ItemOnGrill = FoodTypes.item.COOKED_BURGER;
                break;
        }
        GRItemRenderer.sprite = CookedSprite;
        GRItemRenderer.color = new Color(255f, 255f, 255f, 1f);
        slider.value = 0;
        slider.gameObject.SetActive(false);
    }

    void ClearGrill()
    {
        ItemOnGrill = FoodTypes.item.NONE;
        
        GRItemRenderer.sprite = UncookedSprite;
        GRItemRenderer.color = new Color(0f, 0f, 0f, 0f);
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
