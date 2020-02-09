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
    private float _averageCarryCapacity = 12;
    private float _carryCapacityMult = 5;

    public float CarryCapacity { get; protected set; }
    public float CurrentWeight { get; protected set; }
    public float EncomberanceMul { get; protected set; }

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
        CarryCapacity = _averageCarryCapacity * _carryCapacityMult;
        EncomberanceMul = 1;
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
        foreach (Slot slot1 in _slots) {
            if (slot1.Item == slot.Item) {
                slot1.Count += slot.Count;
                slot1.Weight += slot.Weight;
                CurrentWeight += slot.Weight;
                if (CurrentWeight <= CarryCapacity) {
                    EncomberanceMul = 1.0f;
                } else if (CurrentWeight <= CarryCapacity * 2) {
                    EncomberanceMul = Mathf.Lerp(1, 0, (CurrentWeight - CarryCapacity) / (CarryCapacity));
                } else {
                    EncomberanceMul = 0;
                }
                return;
            }
        }
        _slots.Add(slot);
        CurrentWeight += slot.Weight;
        slot.RegisterOnSlotModified(OnSlotModified);
        if (CurrentWeight <= CarryCapacity) {
            EncomberanceMul = 1.0f;
        } else if (CurrentWeight <= CarryCapacity * 2) {
            EncomberanceMul = Mathf.Lerp(1, 0, (CurrentWeight-CarryCapacity) / (CarryCapacity));
        } else {
            EncomberanceMul = 0;
        }
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
        foreach (Slot slot1 in _slots) {
            if (slot1.Item == slot.Item) {
                if (slot.Count > slot1.Count)
                    slot.setItem(slot1.Item, slot1.Count);
                slot1.Count -= slot.Count;
                slot1.Weight -= slot.Weight;
                if (slot1.Count == 0) {
                    _slots.Remove(slot1);
                    if (_removeSlotAction != null)
                        _removeSlotAction(slot1);
                }
                if (CurrentWeight <= CarryCapacity) {
                    EncomberanceMul = 1.0f;
                } else if (CurrentWeight <= CarryCapacity * 2) {
                    EncomberanceMul = Mathf.Lerp(1, 0, (CurrentWeight - CarryCapacity) / (CarryCapacity));
                } else {
                    EncomberanceMul = 0;
                }
                return;
            }
        }
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


    //--------------Callbacks-------------

    /*
     * Function: OnSlotModified
     * Params: 
     *   Slot: the slot that was modified
     * Returns: Void
     * 
     * Callback that is called when a slot is modified. This will handle updating the inventory weight
     * 
     */
    public void OnSlotModified(Slot slot) {
        CurrentWeight = 0;
        foreach(Slot s in _slots) {
            CurrentWeight += s.Weight;
        }
        if (CurrentWeight <= CarryCapacity) {
            EncomberanceMul = 1.0f;
        } else if (CurrentWeight <= CarryCapacity * 2) {
            EncomberanceMul = Mathf.Lerp(1, 0, (CurrentWeight - CarryCapacity) / (CarryCapacity));
        } else {
            EncomberanceMul = 0;
        }
    }

}
