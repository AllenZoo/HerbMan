using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Default, 
    Helmet,
    Chestplate,
    Pants,
    Boots,
    Weapon,
    Orb,
    Pickaxe,
    Axe,
    Sickle,
    Crafting,
    Herb,
    Ore,
    Wood,
    Recipe,
    EnergyShard,
}

public enum Attributes
{
    Attack,
    Defence,
    Speed,
}

//[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class ItemObject : ScriptableObject
{
    public Sprite sprite;
    public bool isStackable;
    public ItemType itemType;

    [TextArea(5, 20)]
    public string description;
    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item {
    public string name;
    public int id = -1;
    public int tier;
    public ItemBuff[] buffs;


    public Item()
    {
        name = "";
        id = -1;
    }

    public Item(ItemObject item)
    {
        //if(item == null)
        //{
        //    return;
        //}

        name = item.name;
        id = item.data.id;
        tier = item.data.tier;

        buffs = new ItemBuff[item.data.buffs.Length];

        for(int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max);
            buffs[i].attribute = item.data.buffs[i].attribute;
        }
    } 


}

[System.Serializable]
public class ItemBuff: IModifier
{
    public Attributes attribute;
    public int min;
    public int max;
    internal int value;

    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }
    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}

