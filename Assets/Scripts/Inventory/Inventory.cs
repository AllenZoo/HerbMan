using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    private Action<Item> useItemAction;

    public event EventHandler OnItemListChanged;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
    }
    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.count += item.count;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
                itemList.Add(item);
            
        }
        else
        {
            itemList.Add(item);
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.count -= item.count;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.count <= 0)
                itemList.Remove(item);

        }
        else
        {
            itemList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void Disable()
    {

    }
    public void UseItem(Item item)
    {
        useItemAction(item);
    }
}
