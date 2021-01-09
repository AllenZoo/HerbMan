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

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void RegisterItemAddedToInventory(ItemAdded itemAdded)
    {
        Debug.Log("Registered method");
        OnItemAddedToInventory += itemAdded;
    }

    public void InvokeItemAddedToInventory(ItemObject itemObject)
    {
        Debug.Log("Item Added To Inventory");
        OnItemAddedToInventory.Invoke(itemObject);
    }
    public void Test()
    {
        print("test");
    }
}


