using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTypes : MonoBehaviour
{
    public enum item
    {
        LETTUCE,
        TOMATO,
        CHOPPED_LETTUCE,
        CHOPPED_TOMATO,
        BURGER,
        COOKED_BURGER,
        PLATE,
        NONE
    }

    public enum recipe_item
    {
        CHOPPED_LETTUCE,
        CHOPPED_TOMATO,
        COOKED_BURGER,
        PLATE,
    }

    public enum station
    {
        GRILL,
        CHOPPING_BOARD
    }

    public static bool IsCompatible(station station, item item)
    {
        if (station == station.GRILL)
        {
            switch (item)
            {
                case (item.BURGER):
                    return true;
                default:
                    return false;
            }
        }
        else if (station == station.CHOPPING_BOARD)
        {
            switch (item)
            {
                case (item.LETTUCE):
                case (item.TOMATO):
                    return true;
                default:
                    return false;
            }
        }
        else
        {
            return false;
        }
    }

}
