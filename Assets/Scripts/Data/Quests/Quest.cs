using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals; //List of subgoals for quest.
    public string Description; //Description of the quest.
    public Quest[] NextQuests; //Quest to add once this is completed.
    public Quests QuestManager;
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
        Quests.QuestsList.Add(this);

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
            Quests.QuestsList.Remove(this);
            if (NextQuests.Length != 0)
                foreach (Quest quest in NextQuests)
                {
                    quest.StartQuest();
                }
            Destroy(gameObject);
        }
        QuestManager.Update();
    }
}
