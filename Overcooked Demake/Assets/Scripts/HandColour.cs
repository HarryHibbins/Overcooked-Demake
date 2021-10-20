using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColour : MonoBehaviour
{
    public FoodTypes.item PlayerItem;
    private GameObject hand;
    private bool colourChanged;


    private SpriteRenderer renderer;
    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        renderer = hand.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        


       
        
   
    }

    public void ChangeColour()
    {
        if (PlayerItem == FoodTypes.item.LETTUCE )
        {
            renderer.color = new Color(0f, 255f, 0f, 1f); 
            Debug.Log("Change hand to lettuce colour");

        }
        else if (PlayerItem == FoodTypes.item.TOMATO)
        {
            //Doesnt work because the referance to FOOD on the player is only set to the lettuce storage
            renderer.color = new Color(255f, 0f, 0f, 1f); 
            Debug.Log("Change hand to tomato colour");
        }
    }
}