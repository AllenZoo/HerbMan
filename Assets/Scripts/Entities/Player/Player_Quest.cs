﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Player_Quest : MonoBehaviour
{
    internal Player player;
    private List<Quest> quests;

    private void Awake()
    {
        player = GetComponent<Player>();
        quests = new List<Quest>();
    }

    private void Start()
    {
        player.player_Event.RegisterItemAddedToInventory(ItemGathered);
    }

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }
    public void RemoveQuest(Quest quest)
    {
        quests.Remove(quest);
    }

    public void OpenQuestWindow()
    {

    }
    public void ItemGathered(ItemObject item)
    {
        Debug.Log(item.name + " gathered.");
        if (quests.Count >= 1)
        {
            quests[0].questGoal.ItemGathered(item);

            if (quests[0].questGoal.IsReached())
            {
                player.player_Event.InvokeQuestCompleted(quests[0]);
                Debug.Log("Quest Complete!");
            }
        }

        
    }

    public Quest GetCurQuest()
    {
        if (quests.Count >= 1)
        {
            return quests[0];
        }
        return null;
    }

    public bool IsQuestComplete()
    {
        return quests[0].isComplete;
    }
    public List<Quest> GetQuestList()
    {
        return quests;
    }
}
