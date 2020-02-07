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
    public int InitialInventorySize = 30; //The initial size of the inventory

    private bool _isInventoryOpen = false;//True if inventory is open, false otherwise
    private Inventory _inventory; //The inventory data

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
     * Unity build in function. Will run on the start of the game, just initializes some values.
     * 
     */
    public void Start() {
        _inventory = new Inventory(InitialInventorySize);
        InitializeInventoryUI(_inventory.Size);
    }

}
