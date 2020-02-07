/*
 *
 * File: InventoryController.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Inventory Class
 * 
 * Contains the inventory data for the player
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class Inventory{


    public int Size { get; protected set; } //The size of the inventory

    /*
     * Function: Inventory
     * Params:
     *   size: the initial size of the inventory.
     * Returns: None
     * 
     * Constructor.
     * Just sets the size of the inventory, for now.
     * 
     */
    public Inventory(int size) {
        Size = size;
    }

}
