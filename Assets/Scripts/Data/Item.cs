/*
 *
 * File: Item.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { 
    Red,Green,Blue
}

/*
 * Item Class
 * 
 * Contains the data for an item.
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class Item{
    
    public ItemType Type = ItemType.Red;

    public Item(ItemType type) {
        Type = type;
    }

}
