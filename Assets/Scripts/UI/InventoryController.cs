/*
 *
 * File: InventoryController.cs
 * Author: Samuel
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Inventory Controller Class
 * 
 * Controlls the interaction between the Unity UI system, and the player's inventory.
 * Note: This class does not contain the actuall inventory, it only manages the interaction.
 * 
 */
public class InventoryController : MonoBehaviour{

    public GameObject SlotGameObject; //Prefab for slot gameobject
    public GameObject InventoryPanel; //The inventory's panel object
    public GameObject InventoryObject; //The root inventory object in the heirarchy

    private bool _isInventoryOpen = false;//True if inventory is open, false otherwise
    private Inventory _inventory; //The inventory data
    private Dictionary<Slot, GameObject> _slotDictionary; //A dictionary to keep track of all the slots linked to the game objects

    /*
     * Function: InitializeInventoryUI
     * Params: 
     *   int invSize: the size of the inventory.
     * Returns: Void
     * 
     * Removes any existing inventory screen, then creates one with the specified size.
     * 
     */
    public void InitializeInventoryUI(int invSize) {
        //Remove existing inventory slots
        foreach(GameObject go in InventoryPanel.transform){
            Destroy(go);
        }

        //Add inventoy slots up to inventory size
        for(int i = 0; i < invSize; i++) {
            GameObject go = Instantiate(SlotGameObject);
            go.transform.SetParent(InventoryPanel.transform);
        }
    }

    /*
     * Function: Update
     * Params: None
     * Returns: Void
     * 
     * Builtin Unity Update function, runs once every frame. Checks for user input pertaining to Inventory, and processes it.
     * 
     */
    public void Update() {
        //check for inventory key, and toggle inventory display
        if (Input.GetButtonDown("Inventory")) {
            if (!_isInventoryOpen) {
                openInventory();
            } else {
                closeInventory();
            }
            _isInventoryOpen = !_isInventoryOpen;
        }


        //TEMPORARY
        if (Input.GetButtonDown("Add")) {
            ItemType type = (ItemType)Random.Range(0, 3);
            _inventory.Add(new Slot(new Item(type)));
        }
        if (Input.GetButtonDown("Remove")) {
            _inventory.Remove(_inventory.Size-1);
        }
    }

    private void openInventory() {
        InventoryObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void closeInventory() {
        InventoryObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /*
     * Function: Start
     * Params: None
     * Returns: Void
     * 
     * Unity built in function. Will run on the start of the game, just initializes some values.
     * 
     */
    public void Start() {
        _inventory = new Inventory();
        _slotDictionary = new Dictionary<Slot, GameObject>();

        //register callbacks
        _inventory.RegisterOnSlotAdded(OnSlotAdded);
        _inventory.RegisterOnSlotRemoved(OnSlotRemoved);
        ItemType type = (ItemType)Random.Range(0, 3);
        _inventory.Add(new Slot(new Item(type)));
        //InitializeInventoryUI(_inventory.Size);
    }

    //--------------Callbacks-------------------

    /*
     * Function: OnSlotAdded
     * Params: 
     *   Slot: the slot that was added
     * Returns: Void
     * 
     * Callback that is called when a new slot is added. This will handle updating the UI
     * 
     */
    public void OnSlotAdded(Slot slot) {
        GameObject go = Instantiate(SlotGameObject);
        go.transform.SetParent(InventoryPanel.transform);
        Image im = go.GetComponent<Image>();
        Color color = Color.white;
        switch (slot.Item.Type) {
            case ItemType.Red:
                color = Color.red;
                break;
            case ItemType.Blue:
                color = Color.blue;
                break;
            case ItemType.Green:
                color = Color.green;
                break;
        }
        im.color = color;
        go.GetComponent<Button>().onClick.AddListener(() => { OnSlotClick(slot); });
        _slotDictionary.Add(slot, go);
        slot.RegisterOnSlotModified(OnSlotModified);
    }

    /*
     * Function: OnSlotRemoved
     * Params: 
     *   Slot: the slot that was removed
     * Returns: Void
     * 
     * Callback that is called when a slot is removed. This will handle updating the UI
     * 
     */
    public void OnSlotRemoved(Slot slot) {
        Destroy(_slotDictionary[slot]);
        _slotDictionary.Remove(slot);
    }

    /*
     * Function: OnSlotModified
     * Params: 
     *   Slot: the slot that was modified
     * Returns: Void
     * 
     * Callback that is called when a slot is modified. This will handle updating the UI
     * 
     */
    public void OnSlotModified(Slot slot) {
        GameObject go = _slotDictionary[slot];
        Image im = go.GetComponent<Image>();
        Color color = Color.white;
        switch (slot.Item.Type) {
            case ItemType.Red:
                color = Color.red;
                break;
            case ItemType.Blue:
                color = Color.blue;
                break;
            case ItemType.Green:
                color = Color.green;
                break;
        }
        im.color = color;
    }

    /*
     * Function: OnSlotClick
     * Params: 
     *   Slot: the slot that was clicked
     * Returns: Void
     * 
     * Callback that is called when a slot is clicked. This will handle updating the inventory.
     * 
     */
    public void OnSlotClick(Slot slot) {
        ItemType type = ItemType.Red;
        switch (slot.Item.Type) {
            case ItemType.Red:
                type = ItemType.Blue;
                break;
            case ItemType.Blue:
                type = ItemType.Green;
                break;
            case ItemType.Green:
                type = ItemType.Red;
                break;
        }
        slot.Item = new Item(type);
    }

}
