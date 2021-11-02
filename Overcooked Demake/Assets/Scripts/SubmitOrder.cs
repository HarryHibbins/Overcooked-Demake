using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitOrder : MonoBehaviour
{
    private bool inBox;
    private GameObject player;
    private PlayerInteractables playerInteractables;
    public PlayerInventory PlayerInventory;
    private RecipeGen generatedRecipe;
    private GameObject recipeGen;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory = player.GetComponent<PlayerInventory>();
        playerInteractables = player.GetComponent<PlayerInteractables>();
        recipeGen = GameObject.FindGameObjectWithTag("GameManager");
        generatedRecipe = recipeGen.GetComponent<RecipeGen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inBox && playerInteractables.canUseSS && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem)
        {
            PlayerInventory.ClearHand();
            PlayerInventory.holdingItem = false;
            Debug.Log("Order submitted");

            if (generatedRecipe.CheckRecipe(generatedRecipe.recipe))
            {
                generatedRecipe.recipe1_matched = true;
                Debug.Log("Recipe 1 complete");
            }
            else if (generatedRecipe.CheckRecipe(generatedRecipe.recipe_2))
            {
                generatedRecipe.recipe2_matched = true;
                Debug.Log("Recipe 2 complete");
            }
            else if (generatedRecipe.CheckRecipe(generatedRecipe.recipe_3))
            {
                generatedRecipe.recipe3_matched = true;
                Debug.Log("Recipe 3 complete");
            }
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform == player.transform)
        {
            inBox = true;
            Debug.Log("in serving station box");
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
