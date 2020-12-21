using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Assets/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory container;


    public void AddItem(Item _item, int _amount)
    {

        //Check if stackable
        if(_item.buffs.Length != 0)
        {
            container.items.Add(new InventorySlot(_item.id, _item, _amount));
            return;
        }

        for(int i = 0; i < container.items.Count; i++)
        {
            if(container.items[i].item.id == _item.id)
            {
                container.items[i].AddAmount(_amount);
                return;
            }
        }
        container.items.Add(new InventorySlot(_item.id, _item, _amount));
    }

    [ContextMenu("Save")]
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container = new Inventory();
    }
}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public int id;
    public Item item;
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int num)
    {
        amount += num;
    }
}
