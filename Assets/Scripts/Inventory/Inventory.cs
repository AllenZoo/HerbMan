using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public event EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.IronAxe, count = 3 });
        AddItem(new Item { itemType = Item.ItemType.StonePickaxe, count = 1 });

        
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void Disable()
    {

    }
}
