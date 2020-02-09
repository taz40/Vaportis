/* Filename: Quests.cs
 * Author: Caleb
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Quests class
 * 
 * Keeps track of the player's quests.
 */
public class Quests : MonoBehaviour
{
    public static List<Quest> QuestsList = new List<Quest>();
    public Text QuestText;
    [HideInInspector]public string Description; //The string to display containing quest data.

    public void Update()
    {
        if (QuestsList.Count == 0)
        {
            QuestText.text = "No Available Quests.";
            return;
        }

        Description = "";
        foreach(Quest quest in QuestsList)
        {
            Description += quest.CurrentDescription + "\n";
        }

        QuestText.text = Description;
    }

}