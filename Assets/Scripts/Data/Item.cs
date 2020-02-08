/*
 *
 * File: Item.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Item Class
 * 
 * Contains the data for an item.
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class Item{

    public string Name { get; protected set; } //The user-facing name of the item
    public ItemType Type { get; protected set; } //The type of the item
    public bool IsResource { get; protected set; } //If the item is a resource or not(amounts of resources are tracked by weight, not by item counts)
    public float WeightPerItem { get; protected set; } //The weight per item, this is 0 for a resource, which isnt tracked by count
    public Color UIColor { get; protected set; } //The color of the item in the UI, will be replaced with a texture in the future

    public Item(string name, ItemType type, bool isResource, float weightPerItem, Color uiColor) {
        Name = name;
        Type = type;
        IsResource = isResource;
        WeightPerItem = weightPerItem;
        UIColor = uiColor;
    }

}
