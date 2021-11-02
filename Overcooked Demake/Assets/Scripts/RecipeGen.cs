using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class RecipeGen : MonoBehaviour
{

    public List<FoodTypes.recipe_item> recipe;
    public List<FoodTypes.recipe_item> recipe_2;
    public List<FoodTypes.recipe_item> recipe_3;
    public bool recipe1_matched;
    public bool recipe2_matched;
    public bool recipe3_matched;
    public GameObject game_manager;
    public GameObject player_hand;
	public GameObject sprite_holder;
	public GameObject sprite_holder_2;
	public GameObject sprite_holder_3;
    private bool showRecipeOne = false;
    private bool showRecipeTwo = false;
    private bool showRecipeThree = false;

	public Sprite LettuceSprite;
	public Sprite TomatoSprite;
	public Sprite BurgerSprite;
    //refers to number of ingredients in recipe
    int complexity = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //automatically fetches required objects so they dont have to be manually assigned, and then generates the first recipe, changed start to awake in the event we add a menu
        game_manager = GameObject.FindGameObjectWithTag("GameManager");
        player_hand = GameObject.FindGameObjectWithTag("Hand");
		sprite_holder = GameObject.FindGameObjectWithTag("RecipeDisplay");
		sprite_holder_2 = GameObject.FindGameObjectWithTag("RecipeDisplay2");
		sprite_holder_3 = GameObject.FindGameObjectWithTag("RecipeDisplay3");
    }

    // Update is called once per frame
    void Update()

    {
        InitialiseRecipies();

        //check if the recipe matched bool has become true, if so reset to false and generate a new recipe and call updatescore
        if (recipe1_matched) 
        {
            recipe1_matched = false;
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time, sprite_holder);
            AssignScore();
        }
        if (recipe2_matched)
        {
            recipe2_matched = false;
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time, sprite_holder_2);
            AssignScore();
        }
        if (recipe3_matched)
        {
            recipe3_matched = false;
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time, sprite_holder_3);
            AssignScore();
        }
    }

    void InitialiseRecipies()
    {
        if (game_manager.GetComponent<Timer>().elapsed_time > 0 && !showRecipeOne)
        {
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time, sprite_holder);
            showRecipeOne = true;
        }
        if (game_manager.GetComponent<Timer>().elapsed_time > 30 && !showRecipeTwo)
        {
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time, sprite_holder_2);
            showRecipeTwo = true;
        }
        if (game_manager.GetComponent<Timer>().elapsed_time > 60 && !showRecipeThree)
        {
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time, sprite_holder_3);
            showRecipeThree = true;
        }
    }

    void AssignScore()
    {
        if (complexity == 3)
        {
            game_manager.GetComponent<Score>().UpdateScore(50, 30);
        }
        else if (complexity == 4)
        {
            game_manager.GetComponent<Score>().UpdateScore(100, 30);
        }
        else if (complexity == 5)
        {
            game_manager.GetComponent<Score>().UpdateScore(200, 45);
        }
    }

    void GenerateRecipe(float time, GameObject recipe_number) 
    {
        if (recipe_number == sprite_holder)
        {
            recipe.Clear();
            recipe.Add(FoodTypes.recipe_item.PLATE);
        }
        else if (recipe_number == sprite_holder_2)
        {
            recipe_2.Clear();
            recipe_2.Add(FoodTypes.recipe_item.PLATE);
        }
        else if (recipe_number == sprite_holder_3)
        {
            recipe_3.Clear();
            recipe_3.Add(FoodTypes.recipe_item.PLATE);
        }

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

        if (recipe_number == sprite_holder)
        {
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
                switch (recipe[i + 1])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (i).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
            if (complexity > 3)
            {
                switch (recipe[4])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (3).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
            if (complexity > 4)
            {
                switch (recipe[5])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (4).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
        }
        else if (recipe_number == sprite_holder_2)
        {
            for (int i = 0; i < complexity; i++)
            {
                int x = Random.Range(0, 3);
                switch (x)
                {
                    case 0:
                        recipe_2.Add(FoodTypes.recipe_item.CHOPPED_LETTUCE);
                        break;
                    case 1:
                        recipe_2.Add(FoodTypes.recipe_item.CHOPPED_TOMATO);
                        break;
                    case 2:
                        recipe_2.Add(FoodTypes.recipe_item.COOKED_BURGER);
                        break;
                }

            }

            // FOR DISPLAYING ON SCREEN
            for (int i = 0; i < 3; i++)
            {
                switch (recipe_2[i + 1])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (i).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
            if (complexity > 3)
            {
                switch (recipe_2[4])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (3).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
            if (complexity > 4)
            {
                switch (recipe_2[5])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (4).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
        }
        else if (recipe_number == sprite_holder_3)
        {
            for (int i = 0; i < complexity; i++)
            {
                int x = Random.Range(0, 3);
                switch (x)
                {
                    case 0:
                        recipe_3.Add(FoodTypes.recipe_item.CHOPPED_LETTUCE);
                        break;
                    case 1:
                        recipe_3.Add(FoodTypes.recipe_item.CHOPPED_TOMATO);
                        break;
                    case 2:
                        recipe_3.Add(FoodTypes.recipe_item.COOKED_BURGER);
                        break;
                }

            }

            // FOR DISPLAYING ON SCREEN
            for (int i = 0; i < 3; i++)
            {
                switch (recipe_3[i + 1])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (i).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
            if (complexity > 3)
            {
                switch (recipe_3[4])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (3).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
            if (complexity > 4)
            {
                switch (recipe_3[5])
                {
                    case FoodTypes.recipe_item.CHOPPED_LETTUCE:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = LettuceSprite;
                        break;
                    case FoodTypes.recipe_item.CHOPPED_TOMATO:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = TomatoSprite;
                        //sprite_holder.transform.GetChild (4).transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
                        break;
                    case FoodTypes.recipe_item.COOKED_BURGER:
                        recipe_number.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                        break;
                }
            }
        }

        //randomly selects ingredients for each slot in the list
        

    }

    public bool CheckRecipe(List<FoodTypes.recipe_item> checklist) 
    {
        List<FoodTypes.recipe_item> checklist_ingredients = new List<FoodTypes.recipe_item>();
        foreach (FoodTypes.recipe_item item in checklist)
        {
            checklist_ingredients.Add(item);
        }
        Debug.Log("Test");
        //gets the plate as the child of the hand game object

        GameObject plate = player_hand.transform.GetChild(0).gameObject;

        //if the player is not holding a plate than checkrecipe is false
        if (plate == null) 
        {
            Debug.Log("no plate");
            return false;
            

        }
        //create a list to store all ingredients on the plate
        List<GameObject> held_ingredients = new List<GameObject>();
        foreach (Transform child in plate.transform)
        {
                held_ingredients.Add(child.gameObject);            
        }
        //loops through every ingredient on the plate
        foreach (GameObject ingredient in held_ingredients) 
        {
            //then it checks each ingredient in the recipe and if it finds one that matches the currently checked ingredient on the plate it removes it from the checklist and then breaks to move
            //              on to the next held ingredient
            foreach (FoodTypes.recipe_item required_item in checklist_ingredients) 
            {
                if (ingredient.tag == required_item.ToString()) 
                {
                    checklist_ingredients.Remove(required_item);
                    Debug.Log("break");
                    break; 
                }
            }
        }

        if (checklist_ingredients.Count != 1)
        {
            Debug.Log("False noooo");
            return false;
            
        }
        else
        {
            Debug.Log("True yesssss");
            return true;
            
        }
    }
}
