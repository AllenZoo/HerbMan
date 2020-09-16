using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    private Action<Item> useItemAction;
    public InventorySlot[] inventorySlotArray;

    public event EventHandler OnItemListChanged;

    public Inventory(Action<Item> useItemAction, int inventorySlotCount)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        inventorySlotArray = new InventorySlot[inventorySlotCount];
        for (int i = 0; i < inventorySlotCount; i++)
        {
            inventorySlotArray[i] = new InventorySlot(i);
        }
        
        AddItem(new Item { itemType = Item.ItemType.Iron_Pickaxe, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Iron_Axe, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Iron_Sickle, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Amatite_Axe, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Amatite_Pickaxe, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Amatite_Sickle, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Hemm, count = 3, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Flint, count = 3, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Stick, count = 3, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Stone_Pickaxe_Recipe, count = 1, system = Item.SystemType.inventory });
        AddItem(new Item { itemType = Item.ItemType.Iron_Pickaxe_Recipe, count = 1, system = Item.SystemType.inventory });
    }

    public InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.IsEmpty())
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find an empty InventorySlot!");
        return null;
    }
    public InventorySlot GetInventorySlotWithItem(Item item)
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.GetItem() == item)
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find Item " + item + " in a InventorySlot!");
        return null;
    }

    public void AddItem(Item item)
    {
        //Debug.Log(item.itemType.ToString());
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
            {
                Item tempItem = item;
                tempItem.system = Item.SystemType.inventory;

                itemList.Add(tempItem);
                GetEmptyInventorySlot().SetItem(tempItem);
            }
        }
        else
        {
            Item tempItem = item;
            tempItem.system = Item.SystemType.inventory;

            itemList.Add(tempItem);
            GetEmptyInventorySlot().SetItem(tempItem);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveItemAmount(Item.ItemType itemType, int count)
    {
        RemoveItem(new Item { itemType = itemType, count = count });
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
            {
                GetInventorySlotWithItem(itemInInventory).RemoveItem();
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            GetInventorySlotWithItem(item).RemoveItem();
            itemList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddItem(Item item, InventorySlot inventorySlot)
    {
        int tempCount = item.count;

        RemoveItem(item);

        inventorySlot.SetItem(item);
        inventorySlot.SetCount(tempCount);
        inventorySlot.SetSystemType(Item.SystemType.inventory);

        itemList.Add(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddItemFromEquipmentSlot(Item item, InventorySlot inventorySlot)
    {
        int tempCount = item.count;

        inventorySlot.SetItem(item);
        inventorySlot.SetCount(tempCount);
        inventorySlot.SetSystemType(Item.SystemType.inventory);

        itemList.Add(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
    public void UseItem(Item item)
    {
        useItemAction(item);
    }
    public InventorySlot[] GetInventorySlotArray()
    {
        return inventorySlotArray;
    }
    /*
     * Represents a single Inventory Slot
     * */
    public class InventorySlot
    {

        private int index;
        private Item item;

        public InventorySlot(int index)
        {
            this.index = index;
        }

        public Item GetItem()
        {
            return item;
        }

        public void SetItem(Item item)
        {
            this.item = item;
            item.system = Item.SystemType.inventory;
        }

        public void RemoveItem()
        {
            item = null;
        }

        public int GetCount()
        {
            if (item != null)
            {
                return item.count;
            }
            else
            {
                return 0;
            }
        }
        public void SetCount(int count)
        {
            item.count = count;
        }
        public Item.SystemType GetSystemType()
        {
            return item.system;
        }
        public void SetSystemType(Item.SystemType systemType)
        {
            item.system = systemType;
        }
        public bool IsEmpty()
        {
            return item == null;
        }

    }
}
