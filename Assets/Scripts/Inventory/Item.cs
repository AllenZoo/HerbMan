using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        //Tools
        StonePickaxe,
        IronPickaxe,
        AmatitePickaxe,
        StoneAxe,
        IronAxe,
        AmatiteAxe,
        StoneSickle,
        IronSickle,
        AmatiteSickle,

        //Herbs
        Melom,
        WaterHerb,
        MellowMint,

        //Ores
        Stone,
        IronOre,
        AmatiteOre,

        //Trees
        Oak,
        Pine,
        Redwood,
    }

    public ItemType itemType;
    public int count;

    public Sprite GetSprite()
    {
        return GetSprite(itemType);
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.StonePickaxe:return ItemAssets.Instance.StonePickaxe;
            case ItemType.IronPickaxe:return ItemAssets.Instance.IronPickaxe;
            case ItemType.AmatitePickaxe:return ItemAssets.Instance.AmatitePickaxe;
            case ItemType.StoneAxe:return ItemAssets.Instance.StoneAxe;
            case ItemType.IronAxe:return ItemAssets.Instance.IronAxe;
            case ItemType.AmatiteAxe:return ItemAssets.Instance.AmatiteAxe;
            case ItemType.StoneSickle:return ItemAssets.Instance.StoneSickle;
            case ItemType.IronSickle:return ItemAssets.Instance.IronSickle;
            case ItemType.AmatiteSickle: return ItemAssets.Instance.AmatiteSickle;
        }
    }

    public bool IsStackable()
    {
        return IsStackable(itemType);
    }

    public static bool IsStackable(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.StonePickaxe:
            case ItemType.IronPickaxe:
            case ItemType.AmatitePickaxe:
            case ItemType.StoneAxe:
            case ItemType.IronAxe:
            case ItemType.AmatiteAxe:
            case ItemType.StoneSickle:
            case ItemType.IronSickle:
            case ItemType.AmatiteSickle:return false;

            //Materials
            case ItemType.Melom:
            case ItemType.MellowMint:
            case ItemType.WaterHerb:
            case ItemType.Stone:
            case ItemType.IronOre:
            case ItemType.AmatiteOre:
            case ItemType.Oak:
            case ItemType.Pine:
            case ItemType.Redwood:return true;
        }
    }

    public Boolean IsTool()
    {
        switch (itemType)
        {
            default: return false;
            case ItemType.StonePickaxe:
            case ItemType.IronPickaxe:
            case ItemType.AmatitePickaxe:
            case ItemType.StoneAxe:
            case ItemType.IronAxe:
            case ItemType.AmatiteAxe:
            case ItemType.StoneSickle:
            case ItemType.IronSickle:
            case ItemType.AmatiteSickle: return true;
        }
    }

    public Boolean IsMaterial()
    {
        switch (itemType)
        {
            default: return false;

            //Herbs
            case ItemType.Melom:
            case ItemType.WaterHerb:
            case ItemType.MellowMint:

            //Ores
            case ItemType.Stone:
            case ItemType.IronOre:
            case ItemType.AmatiteOre:

            //Trees
            case ItemType.Oak:
            case ItemType.Pine:
            case ItemType.Redwood:
                return true;
        }
    }

    public String ToStringG()
    {
        return itemType.ToString();
    }
}
