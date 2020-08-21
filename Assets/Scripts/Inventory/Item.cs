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
        Sparkle_Weed,
        Water_Herb,
        Mellow_Mint,

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

    public Boolean IsStackable()
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
}
