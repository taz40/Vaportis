using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals; //List of subgoals for quest.
    public string Description; //Description of the quest.
    public Quest nextQuest; //Quest to add once this is completed.

    void Start()
    {
        if (Goals.Count == 1)
            Description = Goals[0].Description;
        else
        {
            string desc = "";
            foreach(Goal goal in Goals)
            {
                desc += goal.Description + "\n";
            }
            Description = desc;
        }
    }
}
