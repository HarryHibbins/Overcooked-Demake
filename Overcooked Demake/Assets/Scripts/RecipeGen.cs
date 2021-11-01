using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeGen : MonoBehaviour
{

    public List<FoodTypes.recipe_item> recipe;
    public bool recipe_matched;
    public GameObject game_manager;
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("GameManager");
        GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time);
                
    }

    // Update is called once per frame
    void Update()
    {
        if (recipe_matched) 
        {
            recipe_matched = false;
            GenerateRecipe(game_manager.GetComponent<Timer>().elapsed_time);
            game_manager.GetComponent<Score>().UpdateScore();
        }

    }


    void GenerateRecipe(float time) 
    {
        recipe.Clear();
        recipe.Add(FoodTypes.recipe_item.PLATE);
        int complexity = 0;
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
    }
}
