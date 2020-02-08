/*
 *
 * File: Inventory.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Inventory Class
 * 
 * Contains the inventory data for the player
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class Inventory {


    private List<Slot> _slots;
    private Action<Slot> _addSlotAction;
    private Action<Slot> _removeSlotAction;

    public int Size {
        get{
            return _slots.Count;
        }
    }


    /*
     * Function: Inventory
     * Params: None
     * Returns: None
     * 
     * Constructor.
     * Initializes the array of slot elements
     * 
     */
    public Inventory() {
        _slots = new List<Slot>();
    }


    /*
     * Function: Add
     * Params: 
     *   slot: the slot data to add to the inventory.
     * Returns: None
     * 
     * Adds the slot to the inventory, then calls the callback to notify UI.
     * 
     */
    public void Add(Slot slot) {
        _slots.Add(slot);
        if (_addSlotAction != null)
            _addSlotAction(slot);
    }


    /*
     * Function: Remove
     * Params: 
     *   slot: the slot data to remove from the inventory.
     * Returns: None
     * 
     * Removes the slot from the inventory, then calls the callback to notify UI.
     * 
     */
    public void Remove(Slot slot) {
        _slots.Remove(slot);
        if (_removeSlotAction != null)
            _removeSlotAction(slot);
    }

    /*
     * Function: Remove
     * Params: 
     *   index: the index of the slot data to remove from the inventory.
     * Returns: None
     * 
     * Removes the slot from the inventory, then calls the callback to notify UI.
     * 
     */
    public void Remove(int index) {
        if (_removeSlotAction != null)
            _removeSlotAction(_slots[index]);
        _slots.RemoveAt(index);
    }



    //-----------Callback register and unregister------------------------

    /*
     * Function: RegisterOnSlotAdded
     * Params: 
     *   cb: the callback to register
     * Returns: None
     * 
     * Registers cb to the callback, so it will fire.
     * 
     */
    public void RegisterOnSlotAdded(Action<Slot> cb) {
        _addSlotAction += cb;
    }

    /*
     * Function: UnregisterOnSlotAdded
     * Params: 
     *   cb: the callback to unregister
     * Returns: None
     * 
     * Unregisters cb from the callback, so it will not fire.
     * 
     */
    public void UnregisterOnSlotAdded(Action<Slot> cb) {
        _addSlotAction -= cb;
    }

    /*
     * Function: RegisterOnSlotRemoved
     * Params: 
     *   cb: the callback to register
     * Returns: None
     * 
     * Registers cb to the callback, so it will fire.
     * 
     */
    public void RegisterOnSlotRemoved(Action<Slot> cb) {
        _removeSlotAction += cb;
    }

    /*
     * Function: UnregisterOnSlotRemoved
     * Params: 
     *   cb: the callback to unregister
     * Returns: None
     * 
     * Unregisters cb from the callback, so it will not fire.
     * 
     */
    public void UnregisterOnSlotRemoved(Action<Slot> cb) {
        _removeSlotAction -= cb;
    }

}
