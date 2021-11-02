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
    public Sprite ChoppedSprite;
    public Sprite UnchoppedSprite;

    public GameObject handPlaceholder;
    public GameObject lettuceSprite;
    public GameObject choppedLettuceSprite;
    public GameObject tomatoSprite;
    public GameObject choppedTomatoSprite;
    public GameObject plateSprite;
    public GameObject burgerSprite;
    public GameObject cookedBurgerSprite;

    // Start is called before the first frame update
    void Start()
    {
        CurrentItem = FoodTypes.item.NONE;
        holdingItem = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHand()
    {
        switch (CurrentItem)
        {
            case (FoodTypes.item.LETTUCE):
                GameObject spriteLettuce = Instantiate(lettuceSprite, handPlaceholder.transform.position, Quaternion.identity);
                spriteLettuce.transform.parent = handPlaceholder.transform;
                holdingItem = true;
                break;

            case (FoodTypes.item.CHOPPED_LETTUCE):
                GameObject spriteChoppedLettuce = Instantiate(choppedLettuceSprite, handPlaceholder.transform.position, Quaternion.identity);
                spriteChoppedLettuce.transform.parent = handPlaceholder.transform;
                spriteChoppedLettuce.tag = "CHOPPED_LETTUCE";
                holdingItem = true;
                break;

            case (FoodTypes.item.TOMATO):
                GameObject spriteTomato = Instantiate(tomatoSprite, handPlaceholder.transform.position, Quaternion.identity);
                spriteTomato.transform.parent = handPlaceholder.transform;
                holdingItem = true;
                break;

            case (FoodTypes.item.CHOPPED_TOMATO):
                GameObject spriteChoppedTomato = Instantiate(choppedTomatoSprite, handPlaceholder.transform.position, Quaternion.identity);
                spriteChoppedTomato.transform.parent = handPlaceholder.transform;
                spriteChoppedTomato.tag = "CHOPPED_TOMATO";
                holdingItem = true;
                break;

            case (FoodTypes.item.PLATE):
                GameObject spritePlate = Instantiate(plateSprite, handPlaceholder.transform.position, Quaternion.identity);
                spritePlate.transform.parent = handPlaceholder.transform;
                holdingItem = true;
                break;

            case (FoodTypes.item.BURGER):
                GameObject spriteBurger = Instantiate(burgerSprite, handPlaceholder.transform.position, Quaternion.identity);
                spriteBurger.transform.parent = handPlaceholder.transform;
                holdingItem = true;
                break;

            case (FoodTypes.item.COOKED_BURGER):
                GameObject spriteCookedBurger = Instantiate(cookedBurgerSprite, handPlaceholder.transform.position, Quaternion.identity);
                spriteCookedBurger.transform.parent = handPlaceholder.transform;
                spriteCookedBurger.tag = "COOKED_BURGER";
                holdingItem = true;
                break;

            case (FoodTypes.item.NONE):
                ClearHand();
                break;
        }
        
    }

    public void place()
    {
        FindObjectOfType<AudioManager>().Play("Place");
        if (CurrentItem != FoodTypes.item.NONE)
        {
            holdingItem = false;
            ClearHand();
           
        }
    }

    public void ClearHand()
    {
        foreach (Transform child in handPlaceholder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        holdingItem = false;
    }
}
