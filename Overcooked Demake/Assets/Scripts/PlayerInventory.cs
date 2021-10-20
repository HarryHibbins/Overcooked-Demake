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
        if (CurrentItem == FoodTypes.item.LETTUCE || CurrentItem == FoodTypes.item.CHOPPED_LETTUCE)
        {
            renderer.color = new Color(0f, 255f, 0f, 1f); 

        }
        else if (CurrentItem == FoodTypes.item.TOMATO || CurrentItem == FoodTypes.item.CHOPPED_TOMATO)
        {
            renderer.color = new Color(255f, 0f, 0f, 1f); 
        }


        if (CurrentItem == FoodTypes.item.CHOPPED_LETTUCE || CurrentItem == FoodTypes.item.CHOPPED_TOMATO)
        {
            renderer.sprite = ChoppedSprite;
        }
        if (CurrentItem == FoodTypes.item.LETTUCE || CurrentItem == FoodTypes.item.TOMATO || CurrentItem == FoodTypes.item.NONE)
        {
            //Reset to circle/unchopped sprite
            renderer.sprite = UnchoppedSprite;
        }
        Debug.Log("pick up");



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
