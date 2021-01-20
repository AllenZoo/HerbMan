using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QuestType
{
    Collection,
    Adventure,
    Killing,
}
[CreateAssetMenu(fileName = "New Quest", menuName = "Assets/Quests/Quest")]
public class QuestObject : ScriptableObject
{
    public Quest quest;
}

[System.Serializable]
public class Quest 
{
    public bool isComplete
    {
        get { return questGoal.IsReached(); }
    }

    public string name;

    [TextArea(3, 10)]
    public string summary;

    [TextArea(3, 10)]
    public string objective;

    public Sprite objectivePortrait;

    public QuestGoal questGoal;

    public Reward[] rewards;

    //public GameObject endNPC;
}

[System.Serializable]
public class Reward
{
    public ItemObject item;
    public int amount;
}

public class Objective
{

}

