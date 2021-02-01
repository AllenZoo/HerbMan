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

    //public delegate void OnLeveledUp(int level);
    //public event OnLeveledUp OnPlayerLeveledUp;

    public Action OnLeveledUp;
    public Action OnExpChanged;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void RegisterItemAddedToInventory(ItemAdded method)
    {
        OnItemAddedToInventory += method;
    }
    public void InvokeItemAddedToInventory(ItemObject itemObject)
    {
        Debug.Log("Item Added To Inventory");
        OnItemAddedToInventory.Invoke(itemObject);
    }
    public void RegisterQuestCompleted(QuestCompleted method)
    {
        OnQuestCompleted += method;
    }
    public void InvokeQuestCompleted(Quest quest)
    {
        Debug.Log("Quest completed");
        OnQuestCompleted.Invoke(quest);
    }
    public void RegisterOnLeveledUp(Action method)
    {
        OnLeveledUp += method;
    }

    public void InvokeOnLeveledUp()
    {
        OnLeveledUp?.Invoke();
    }

    public void ResgisterOnExpChanged(Action method)
    {
        OnExpChanged += method;
    }
    public void InvokeOnExpChanged()
    {
        OnExpChanged?.Invoke();
    }

    //public void RegisterOnLeveledUp(OnLeveledUp method)
    //{
    //    OnPlayerLeveledUp += method;
    //}

    //public void InvokeOnLeveledUp(int level)
    //{
    //    OnPlayerLeveledUp?.Invoke(level);
    //}

    public void Test()
    {
        print("test");
    }
}


