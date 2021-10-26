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






    // Start is called before the first frame update
    void Start()
    {
        CurrentItem = FoodTypes.item.NONE;
        holdingItem = false;
        hand = GameObject.FindGameObjectWithTag("Hand");
        renderer = hand.GetComponent<SpriteRenderer>();
        UnchoppedSprite = renderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHand()
    {
        // Switch for Hand Colour
        switch (CurrentItem)
        {
            case (FoodTypes.item.LETTUCE):
            case (FoodTypes.item.CHOPPED_LETTUCE):
                renderer.color = new Color(0f, 255f, 0f, 1f);
                break;

            case (FoodTypes.item.TOMATO):
            case (FoodTypes.item.CHOPPED_TOMATO):
                renderer.color = new Color(255f, 0f, 0f, 1f);
                break;

            case (FoodTypes.item.NONE):
                renderer.color = new Color(255f, 255f, 255f);
                break;
        }

        // Switch for Hand Shape
        switch (CurrentItem)
        {
            case (FoodTypes.item.LETTUCE):
            case (FoodTypes.item.TOMATO):
            case (FoodTypes.item.NONE):
                renderer.sprite = UnchoppedSprite;
                break;

            case (FoodTypes.item.CHOPPED_LETTUCE):
            case (FoodTypes.item.CHOPPED_TOMATO):
                renderer.sprite = ChoppedSprite;
                break;
        }
        holdingItem = true;
    }

    public void place()
    {
        if (CurrentItem != FoodTypes.item.NONE)
        {
            renderer.color = new Color(255f, 255f, 255f, 1f);
            renderer.sprite = UnchoppedSprite;
            holdingItem = false;
            Debug.Log("place");
        }


    }


}
