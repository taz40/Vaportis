using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text goalText;

    public int amountRequired = 1; //Amount of times the task must be completed. Set to 1 if it is a boolean task.
    public string Description = ""; //Description of goal.

    [HideInInspector]
    public bool isComplete = false;

    private int amountCompleted = 0;

    void Start()
    {
        if (amountRequired > 1)
            Description += " 0/" + amountRequired;

        goalText.text = Description;
    }

    public void Complete()
    {
        if (isComplete) return;

        amountCompleted++;
        if (amountRequired > 1)
            Description = Description.Substring(0, Description.Length - 3) + amountCompleted + "/" + amountRequired;

        if (amountCompleted == amountRequired) {
            isComplete = true;
            Description = StrikeThrough(Description);
        }

        goalText.text = Description;
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
