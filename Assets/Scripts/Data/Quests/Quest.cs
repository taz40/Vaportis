using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text GoalText;
    public List<Goal> Goals; //List of subgoals for quest.
    public string Description; //Description of the quest.
    public Quest NextQuest = null; //Quest to add once this is completed.
    public bool IsActive; //Should the quest be added when the scene starts?

    [HideInInspector] public string CurrentDescription;
    [HideInInspector] public bool isComplete;

    void Start()
    {
        if (IsActive) StartQuest();
    }

    public void StartQuest()
    {
        IsActive = true;

        foreach (Goal goal in Goals)
        {
            goal.ParentQuest = this;
        }

        Update();
    }

    public void Update()
    {
        if (!IsActive || isComplete) return;
        bool completed = true;

        if (Goals.Count != 1)
        {
            string desc = Description;
            foreach (Goal goal in Goals)
            {
                desc += "\n   " + goal.Description;
                if (!goal.isComplete) completed = false;
            }
            CurrentDescription = desc;
        }
        else
        {
            if (!Goals[0].isComplete) completed = false;
            CurrentDescription = Description + ": "+Goals[0].Description;
        }

        if (completed)
        {
            isComplete = true;
            GoalText.text = "";
            if (NextQuest != null) NextQuest.StartQuest();
            Destroy(gameObject);
            return;
        }
        GoalText.text = CurrentDescription;
    }
}
