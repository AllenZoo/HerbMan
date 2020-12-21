using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Default, 
    Equipment,
    Crafting,
    Healing
}

public enum Attributes
{
    Attack,
    Defence,
    Speed,
}

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public ItemType itemType;

    [TextArea(5, 20)]
    public string description;
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item {
    public string name;
    public int id;
    public ItemBuff[] buffs;
    public Item(ItemObject item)
    {
        name = item.name;
        id = item.id;
        buffs = new ItemBuff[item.buffs.Length];
        for(int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);
            buffs[i].attribute = item.buffs[i].attribute;
        }
    } 
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;

    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}

