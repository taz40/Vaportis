/*
 *
 * File: Health.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Health Class
 * 
 * Manages heath for any object that should have it.
 * 
 */
public class Health : MonoBehaviour {

    public float StartingMaxHealth = 100f; //This is only used for the inspector window, so we can keep the max health protected
    public UnityEvent OnDeathCallback; //This will get called when the object dies, use the inspector to implement functionality
    public UnityEvent OnReviveCallback; //This will get called when the object dies then gets revived(idk if this will be usefull but included it just in case), use the inspector to implement functionality

    public VitalBars UIVitalBars; //The vitalbars to update on the screen, if any.

    public bool IsDead { get; protected set; } //Represents if the object is currently dead or not

    public float CurrentHealth { get; protected set; } //The Health of the object
    public float MaxHealth { get; protected set; } //The max health of the object

    /*
     *
     * Function: Start
     * 
     * Runs on scene load, used to set max health, and health to default values
     * 
     */
    private void Start() {
        MaxHealth = StartingMaxHealth;
        CurrentHealth = MaxHealth;
        if (UIVitalBars != null)
            UIVitalBars.SetMaxHealth(MaxHealth);
    }


    /*
     *
     * Function: DoDamage
     * Params:
     *      amount: the amount of damage to do
     *      
     * does <amount> damage to the object.
     * 
     */
    public void DoDamage(float amount) { 
        if(CurrentHealth <= amount) {
            CurrentHealth = 0;
            if (!IsDead) {
                OnDeathCallback.Invoke();
                IsDead = true;
            }
        } else {
            CurrentHealth -= amount;
        }
        if (UIVitalBars != null)
            UIVitalBars.SetHealth(CurrentHealth);
    }

    /*
    *
    * Function: Heal
    * Params:
    *      amount: the amount of healing to do
    *      
    * Heals the object by <amount>
    * 
    */
    public void Heal(float amount) {
        CurrentHealth += amount;
        if(CurrentHealth > 0 && IsDead) {
            IsDead = false;
            OnReviveCallback.Invoke();
        }else if(CurrentHealth > MaxHealth) {
            CurrentHealth = MaxHealth;
        }
        if (UIVitalBars != null)
            UIVitalBars.SetHealth(CurrentHealth);
    }

}
