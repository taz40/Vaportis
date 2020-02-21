/*
 *
 * File: VitalBars.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * VitalBars Class
 * 
 * Manages all UI vital bars
 * 
 */
public class VitalBars : MonoBehaviour{

    public Slider healthBar; //The slider to update for the health bar

    /*
     *
     * Function: SetHealth
     * Params:
     *      health: the value to set the health bar to
     * 
     * Sets the UI health bar to the corresponding value
     * 
     */
    public void SetHealth(float health) {
        healthBar.value = health;
    }

    /*
     *
     * Function: SetMaxHealth
     * Params:
     *      maxhealth: the value to set the health bar max to
     * 
     * Sets the UI health bar to the corresponding max value
     * 
     */
    public void SetMaxHealth(float maxhealth) {
        healthBar.maxValue = maxhealth;
        healthBar.value = maxhealth;
    }
}
