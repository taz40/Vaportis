using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int amountRequired = 1; //Amount of times the task must be completed. Set to 1 if it is a boolean task.
    public string Description = ""; //Description of goal.

    [HideInInspector] public bool isComplete = false;
    [HideInInspector] public Quest ParentQuest;

    private int _amountCompleted = 0;

    void Start()
    {
        if (amountRequired > 1)
            Description += " 0/" + amountRequired;

        if (ParentQuest != null) ParentQuest.Update();
    }

    public void Complete()
    {
        if (isComplete || ParentQuest == null) return;

        _amountCompleted++;
        if (amountRequired > 1)
            Description = Description.Substring(0, Description.Length - 3) + _amountCompleted + "/" + amountRequired;

        if (_amountCompleted == amountRequired) {
            isComplete = true;
            Description = StrikeThrough(Description);
        }

        ParentQuest.Update();
    }

    string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }
}
