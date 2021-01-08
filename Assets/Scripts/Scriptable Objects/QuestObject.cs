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
public abstract class QuestObject : ScriptableObject
{
    public QuestType questType;
    public Quest quest;
}

[System.Serializable]
public class Quest 
{
    public string name;
    public string summary;
    public string objective;
    public int moneyReward;
    public GameObject endNPC;
}

public class Objective
{

}

