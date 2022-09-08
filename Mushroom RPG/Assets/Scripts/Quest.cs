using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string title;
    public int goldReward;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title);
    }
}
