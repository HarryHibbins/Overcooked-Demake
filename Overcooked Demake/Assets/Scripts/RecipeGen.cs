using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class RecipeGen : MonoBehaviour
{

    public List<FoodTypes.recipe_item> recipe;
    public bool recipe_matched;
    public GameObject game_manager;
    public GameObject player_hand;
	public GameObject sprite_holder;
	public Sprite LettuceSprite;
	public Sprite TomatoSprite;
	public Sprite BurgerSprite;

    // Start is called before the first frame update
    void Awake()
    {
        //automatically fetches required objects so they dont have to be manually assigned, and then generates the first recipe, changed start to awake in the event we add a menu
        game_manager = GameObject.FindGameObjectWithTag("GameManager");
        player_hand = GameObject.FindGameObjectWithTag("Hand");
		sprite_holder = GameObject.FindGameObjectWithTag("RecipeDisplay");
        GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time);                
    }

    // Update is called once per frame
    void Update()

    {
        //check if the recipe matched bool has become true, if so reset to false and generate a new recipe and call updatescore
        if (recipe_matched) 
        {
            recipe_matched = false;
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time);
            game_manager.GetComponent<Score>().UpdateScore();
        }

    }


    void GenerateRecipe(float time) 
    {
        //empties recipe list before generating a new one
        recipe.Clear();
        //all recipes must have a plate
        recipe.Add(FoodTypes.recipe_item.PLATE);
        //refers to number of ingredients in recipe
        int complexity = 0;
        //more items as time goes on
        if (time < 30)
        {
            complexity = 3;
        }
        else if (time < 60)
        {
            complexity = 4;
        }
        else if (time < 90) 
        {
            complexity = 5;        
        }
        //randomly selects ingredients for each slot in the list
        for (int i = 0; i < complexity; i++) 
        {
            int x = Random.Range(0, 3);
            switch (x) 
            {
                case 0:
                    recipe.Add(FoodTypes.recipe_item.CHOPPED_LETTUCE);
                    break;
                case 1:
                    recipe.Add(FoodTypes.recipe_item.CHOPPED_TOMATO);
                    break;
                case 2:
                    recipe.Add(FoodTypes.recipe_item.COOKED_BURGER);
                    break;
            }
            
        }

		// FOR DISPLAYING ON SCREEN
		for (int i = 0; i < 3; i++) 
		{
			switch (recipe [i + 1])
			{
			case FoodTypes.recipe_item.CHOPPED_LETTUCE:
				sprite_holder.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
				break;
			case FoodTypes.recipe_item.CHOPPED_TOMATO:
				sprite_holder.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().sprite = TomatoSprite;
				//sprite_holder.transform.GetChild (i).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
				break;
			case FoodTypes.recipe_item.COOKED_BURGER:
				sprite_holder.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
				break;
			}
		}
		if (complexity > 3) 
		{
			switch (recipe [4])
			{
			case FoodTypes.recipe_item.CHOPPED_LETTUCE:
				sprite_holder.transform.GetChild (3).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
				break;
			case FoodTypes.recipe_item.CHOPPED_TOMATO:
				sprite_holder.transform.GetChild (3).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
				//sprite_holder.transform.GetChild (3).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
				break;
			case FoodTypes.recipe_item.COOKED_BURGER:
				sprite_holder.transform.GetChild (3).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
				break;
			}
		}
		if (complexity > 4) 
		{
			switch (recipe [5])
			{
			case FoodTypes.recipe_item.CHOPPED_LETTUCE:
				sprite_holder.transform.GetChild (4).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
				break;
			case FoodTypes.recipe_item.CHOPPED_TOMATO:
				sprite_holder.transform.GetChild (4).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
				//sprite_holder.transform.GetChild (4).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
				break;
			case FoodTypes.recipe_item.COOKED_BURGER:
				sprite_holder.transform.GetChild (4).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
				break;
			}
		}

    }

    public bool CheckRecipe(List<FoodTypes.recipe_item> checklist) 
    {


        //gets the plate as the child of the hand game object

        GameObject plate = player_hand.transform.GetChild(0).gameObject;

        //if the player is not holding a plate than checkrecipe is false
        if (plate == null) 
        {

            return false;

        }
        //create a list to store all ingredients on the plate
        List<GameObject> held_ingredients = null;
        foreach (Transform child in plate.transform)
        {
                held_ingredients.Add(child.gameObject);            
        }
        //loops through every ingredient on the plate
        foreach (GameObject ingredient in held_ingredients) 
        {
            //if the plate still has more ingredients on it but the recipe on has plate left, then the player has too many and checkrecipe is false
            if (checklist.Count == 1) 
            {
                return false;            
            }
            //then it checks each ingredient in the recipe and if it finds one that matches the currently checked ingredient on the plate it removes it from the checklist and then breaks to move
            //              on to the next held ingredient
            foreach (FoodTypes.recipe_item required_item in checklist) 
            {
                if (ingredient.tag == held_ingredients.ToString()) 
                {
                    checklist.Remove(required_item);
                    break;
                }
            }
            //if it reaches this point the item on the plate was not in the checklist, so return false
            return false;
        }
        // if its reached this point, the checklist recipe should have matched the ingredients on the plate, so checkrecipe is true!
        Debug.Log("Recipe correct");

        return true;
    }
}
