/*
 *
 * File: Items.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Wood, Stone, Brick, Plank
}

/*
 * Items Class
 * 
 * Contains the prefabs for all items in the game.
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class Items {

    public static Dictionary<string, Item> ItemPrefabs = new Dictionary<string, Item>(); //A dictionary of all Items in the game

    static Items(){
        ItemPrefabs.Add("wood", new Item("Wood", ItemType.Wood, true, 0, Color.yellow));
        ItemPrefabs.Add("stone", new Item("Stone", ItemType.Stone, true, 0, Color.grey));
        ItemPrefabs.Add("brick", new Item("Brick", ItemType.Brick, false, 2.25f, Color.red));
        ItemPrefabs.Add("plank", new Item("Plank", ItemType.Plank, false, 1.2f, Color.green));
    }

}
