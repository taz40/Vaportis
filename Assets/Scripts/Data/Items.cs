/*
 *
 * File: Items.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    //Armor/clothing
    Shirt,
    //Weapons
    Sword,
    //Consumable
    Bread,
    //Luxury
    Diamond
}

public enum ItemCategory { 
    Armor, Weapon, Consumable, Luxury
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
        //Consumables
        ItemPrefabs.Add("bread", new Item("Bread", ItemType.Bread, .038f, ItemCategory.Consumable, "bread"));
    }

}
