﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

public enum InterfaceType {
    Inventory,
    Equipment,
    Crafting,
    Quest,
}

[CreateAssetMenu(fileName = "New Inventory", menuName = "Assets/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public InterfaceType type;
    public Inventory container;
    public InventorySlot[] GetSlots { get { return  container.slots; } }

    public bool AddItem(Item _item, int _amount)
    {
        if(type == InterfaceType.Inventory)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            //player.player_Event.InvokeItemAddedToInventory(_item);
        }

        if(EmptySlotCount <= 0)
        {
            return false;
        }
        InventorySlot slot = FindItemOnInventory(_item);
        if(!database.itemObjects[_item.id].isStackable || slot == null)
        {
            SetEmptySlot(_item, _amount);
            return true;
        }
        slot.AddAmount(_amount);
        return true;
    }

    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < GetSlots.Length; i++)
            {
                if(GetSlots[i].item.id <= -1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }

    public InventorySlot FindItemOnInventory(Item _item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.id == _item.id)
            {
                return GetSlots[i];
            }
        }
        return null;
    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.id <= -1)
            {
                GetSlots[i].UpdateSlot(_item, _amount);
                return GetSlots[i];
            }
        }
        //set up functionality for when inventory is full
        return null;
    }

    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if(item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
            InventorySlot temp = new InventorySlot(item2.item, item2.amount);
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(temp.item, temp.amount);
        }
    }

    public void RemoveItem(Item _item)
    {
        for(int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.name == _item.name)
            {
               GetSlots[i].UpdateSlot(null, 0);
            }
        }
    }

    public void RemoveItem(Item _item, int amount)
    {
        int itemsToRemove = amount;
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.name == _item.name)
            {
                var tempAmount = GetSlots[i].amount;
                for (int j = 0; j < tempAmount; j++)
                {
                    Debug.Log("itemsToRemove: " + itemsToRemove  + "Slot amount: " + GetSlots[i].amount);
                    if(itemsToRemove == 0)
                    {
                        Debug.Log("returning from remove item");
                        return;
                    }

                    itemsToRemove--;
                    GetSlots[i].UpdateSlot(GetSlots[i].amount -= 1);
                }
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for(int i = 0; i < GetSlots.Length; i++)
            {
                GetSlots[i].UpdateSlot(newContainer.slots[i].item, newContainer.slots[i].amount);
            }
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container.Clear();
    }
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] slots = new InventorySlot[24];

    private int numSlots;

    public void Clear()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
        }
    }

    public void SetSlots(int amt)
    {
        numSlots = amt;
        ReInitialize();
    }

    public void ReInitialize()
    {
        InventorySlot[] oldVals = (InventorySlot[]) slots.Clone();

        slots = new InventorySlot[numSlots];
        for (int i = 0; i < slots.Length - 1; i++){
            slots[i] = oldVals[i];
        }
        slots[numSlots - 1] = new InventorySlot();
        slots[numSlots - 1].item.id = -1;

    }

}

public delegate void SlotUpdated(InventorySlot _slot);

[System.Serializable]
public class InventorySlot
{
    public ItemType[] allowedItems = new ItemType[0];
    [System.NonSerialized]
    public UserInterface parent;
    [System.NonSerialized]
    public GameObject slotDisplay;
    [System.NonSerialized]
    public SlotUpdated OnAfterUpdate;
    [System.NonSerialized]
    public SlotUpdated OnBeforeUpdate;
    public Item item;
    public int amount;

    public ItemObject ItemObject
    {
        get
        {
            if(item.id >= 0)
            {
                return parent.inventory.database.itemObjects[item.id];
            }
            return null;
        }
    }

    public InventorySlot()
    {
        UpdateSlot(new Item(), 0);
    }

    public InventorySlot(Item _item, int _amount)
    {
        UpdateSlot(_item, _amount);
    }

    public void UpdateSlot(Item _item, int _amount)
    {
        OnBeforeUpdate?.Invoke(this);
        
        item = _item;
        amount = _amount;

        OnAfterUpdate?.Invoke(this);
    }

    public void UpdateSlot(int _amount)
    {
        OnBeforeUpdate?.Invoke(this);

        if(_amount <= 0)
        {
            item.id = -1;
        }

        amount = _amount;

        OnAfterUpdate?.Invoke(this);
    }

    public void RemoveItem()
    {
        UpdateSlot(new Item(), 0);
    }
    public void AddAmount(int _num)
    {
        UpdateSlot(item, amount += _num);
    }
    
    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if(allowedItems.Length <= 0 || _itemObject == null || _itemObject.data.id < 0)
        {
            return true;
        }
        for(int i = 0; i < allowedItems.Length; i++)
        {
            if(_itemObject.itemType == allowedItems[i])
            {
                return true;
            }
        }

        return false;
    }
}
