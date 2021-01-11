using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Events : MonoBehaviour
{
    internal Player player;
    public EventHandler OnCollectedCollectable;
    //public EventHandler OnItemAddedToInventory;

    public delegate void ItemAdded(ItemObject item);
    public event ItemAdded OnItemAddedToInventory;

    public delegate void QuestCompleted(Quest quest);
    public event QuestCompleted OnQuestCompleted;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void RegisterItemAddedToInventory(ItemAdded method)
    {
        Debug.Log("Registered method");
        OnItemAddedToInventory += method;
    }

    public void InvokeItemAddedToInventory(ItemObject itemObject)
    {
        Debug.Log("Item Added To Inventory");
        OnItemAddedToInventory.Invoke(itemObject);
    }

    public void RegisterQuestCompleted(QuestCompleted method)
    {
        Debug.Log("Registered method to Quest Completed");
        OnQuestCompleted += method;
    }

    public void InvokeQuestCompleted(Quest quest)
    {
        Debug.Log("Quest completed");
        OnQuestCompleted.Invoke(quest);
    }
    public void Test()
    {
        print("test");
    }
}


