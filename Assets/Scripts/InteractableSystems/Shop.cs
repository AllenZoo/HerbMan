using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public event EventHandler OnListChanged;

    private List<ItemObject> displayItems;
    private List<ItemObject> buyListItems;
    private List<ItemObject> sellListItems;

    private void Awake()
    {
        displayItems = new List<ItemObject>();
        buyListItems = new List<ItemObject>();
        sellListItems = new List<ItemObject>();
    }

    public enum ShopList { 
        display,
        buy,
        sell,
    }
    public List<ItemObject> GetDisplayItems()
    {
        return displayItems;
    }
    public List<ItemObject> GetBuyListItems()
    {
        return buyListItems;
    }
    public List<ItemObject> GetSellListItems()
    {
        return sellListItems;
    }
    public void AddItemToList(ItemObject item, ShopList sl)
    {
        switch (sl) {
            case ShopList.display: 
                displayItems.Add(item);
                break;
            case ShopList.buy:
                buyListItems.Add(item);
                break;
            case ShopList.sell:
                sellListItems.Add(item);
                break;
        }
        OnListChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
