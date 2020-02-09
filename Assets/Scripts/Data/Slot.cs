
/*
 *
 * File: Slot.cs
 * Author: Samuel
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Slot Class
 * 
 * Contains the data for a single inventory slot
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class Slot {
    private Item _item; //The item in the slot
    private int _count; //The number of the item in the slot
    private float _weight; //The weight of item, only here in case we want to make some items weight based, rather than count based i.e. stone
    private Action<Slot> _onSlotChangedAction;

    //public property for item, calls onSlotChangedAction when modified.
    public Item Item {
        get {
            return _item;
        }

        set {
            _item = value;
            if (_onSlotChangedAction != null)
                _onSlotChangedAction(this);
        }
    }

    //public property for count, calls onSlotChangedAction when modified.
    public int Count {
        get {
            return _count;
        }

        set {
            _count = value;
            if (_onSlotChangedAction != null)
                _onSlotChangedAction(this);
        }
    }

    //public property for weight, calls onSlotChangedAction when modified.
    public float Weight {
        get {
            return _weight;
        }

        set {
            _weight = value;
            if (_onSlotChangedAction != null)
                _onSlotChangedAction(this);
        }
    }

    public Slot() {
    }

    public Slot(Item item, int count = 1){
        setItem(item, count);
    }

    public void setItem(Item item, int count = 1){
        Item = item;
        Count = count;
        Weight = item.WeightPerItem * count;
    }

//---------------Callback Functions---------------------

/*
 * Function: RegisterOnSlotModified
 * Params: 
 *   cb: the callback to register
 * Returns: None
 * 
 * Registers cb to the callback, so it will fire.
 * 
 */
public void RegisterOnSlotModified(Action<Slot> cb) {
        _onSlotChangedAction += cb;
    }

    /*
     * Function: UnregisterOnSlotModified
     * Params: 
     *   cb: the callback to unregister
     * Returns: None
     * 
     * Unregisters cb from the callback, so it will not fire.
     * 
     */
    public void UnregisterOnSlotModified(Action<Slot> cb) {
        _onSlotChangedAction -= cb;
    }

}
