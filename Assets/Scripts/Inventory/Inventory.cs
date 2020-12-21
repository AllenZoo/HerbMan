using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Linq;

public class InventoryOld
{
    private List<ItemOld> itemList;
    private Action<ItemOld> useItemAction;
    public InventorySlot[] inventorySlotArray;

    public event EventHandler OnItemListChanged;

    public InventoryOld(Action<ItemOld> useItemAction, int inventorySlotCount)
    {
        this.useItemAction = useItemAction;
        itemList = new List<ItemOld>();

        inventorySlotArray = new InventorySlot[inventorySlotCount];
        for (int i = 0; i < inventorySlotCount; i++)
        {
            inventorySlotArray[i] = new InventorySlot(i);
        }

        AddItem(new ItemOld { itemType = ItemOld.ItemType.Iron_Axe, count = 1, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Iron_Sickle, count = 1, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Amatite_Sickle, count = 1, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Hemm, count = 8, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.MellowMint, count = 8, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Flint, count = 3, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Stick, count = 3, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Stone_Pickaxe_Recipe, count = 1, system = ItemOld.SystemType.inventory });
        AddItem(new ItemOld { itemType = ItemOld.ItemType.Iron_Pickaxe_Recipe, count = 1, system = ItemOld.SystemType.inventory });
    }
 



    public InventoryOld(int inventorySlotCount)
    {
        itemList = new List<ItemOld>();
        inventorySlotArray = new InventorySlot[inventorySlotCount];
        for (int i = 0; i < inventorySlotCount; i++)
        {
            inventorySlotArray[i] = new InventorySlot(i);
        }
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
    public InventorySlot GetInventorySlotWithItem(ItemOld item)
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

    public void AddItem(ItemOld item)
    {
        //Debug.Log(item.itemType.ToString());
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (ItemOld inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.count += item.count;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                ItemOld tempItem = item;
                tempItem.system = ItemOld.SystemType.inventory;

                itemList.Add(tempItem);
                GetEmptyInventorySlot().SetItem(tempItem);
            }
        }
        else
        {
            ItemOld tempItem = item;
            tempItem.system = ItemOld.SystemType.inventory;

            //Debug.Log("Item count:" + item.count);
            //Debug.Log("tempItem count:" + tempItem.count);
            itemList.Add(tempItem);
            GetEmptyInventorySlot().SetItem(tempItem);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddItemAmount(ItemOld item, int count)
    {

    }
    public void RemoveItemAmount(ItemOld.ItemType itemType, int count)
    {
        RemoveItem(new ItemOld { itemType = itemType, count = count });
    }
    public void RemoveItem(ItemOld item)
    {
        if (item.IsStackable())
        {
            ItemOld itemInInventory = null;
            foreach (ItemOld inventoryItem in itemList)
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
    public void AddItem(ItemOld item, InventorySlot inventorySlot)
    {
        int tempCount = item.count;

        RemoveItem(item);

        inventorySlot.SetItem(item);
        inventorySlot.SetCount(tempCount);
        inventorySlot.SetSystemType(ItemOld.SystemType.inventory);

        itemList.Add(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddItemFromEquipmentSlot(ItemOld item, InventorySlot inventorySlot)
    {
        int tempCount = item.count;

        inventorySlot.SetItem(item);
        inventorySlot.SetCount(tempCount);
        inventorySlot.SetSystemType(ItemOld.SystemType.inventory);

        itemList.Add(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<ItemOld> GetItemList()
    {
        return itemList;
    }
    public void UseItem(ItemOld item)
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
        private ItemOld item;

        public InventorySlot(int index)
        {
            this.index = index;
        }

        public ItemOld GetItem()
        {
            return item;
        }

        public void SetItem(ItemOld item)
        {
            this.item = item;
            //this.item.count = item.count;
            item.system = ItemOld.SystemType.inventory;
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
        public ItemOld.SystemType GetSystemType()
        {
            return item.system;
        }
        public void SetSystemType(ItemOld.SystemType systemType)
        {
            item.system = systemType;
        }
        public bool IsEmpty()
        {
            return item == null;
        }

    }
}
