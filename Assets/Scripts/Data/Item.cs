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
    public ItemCategory Category { get; protected set; } //The category of the item
    public float WeightPerItem { get; protected set; } //The weight per item, this is 0 for a resource, which isnt tracked by count
    public Sprite UISprite { get; protected set; } //The texture to display in the UI

    public Item(string name, ItemType type, float weightPerItem, ItemCategory category, string sprite) {
        Name = name;
        Type = type;
        WeightPerItem = weightPerItem;
        UISprite = SpriteManager.GetSprite(sprite);
        Category = category;
    }

}
