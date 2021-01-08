using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Quest : MonoBehaviour
{
    private List<Quest> quests;
    //private LinkedList<Quest> linkedQuest;

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }
    public void RemoveQuest(Quest quest)
    {
        quests.Remove(quest);
    }

    public List<Quest> GetQuestList()
    {
        return quests;
    }
}
