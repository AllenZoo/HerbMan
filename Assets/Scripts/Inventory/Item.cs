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
                //Tools
            case ItemType.StonePickaxe:return ItemAssets.Instance.StonePickaxe;
            case ItemType.IronPickaxe:return ItemAssets.Instance.IronPickaxe;
            case ItemType.AmatitePickaxe:return ItemAssets.Instance.AmatitePickaxe;
            case ItemType.StoneAxe:return ItemAssets.Instance.StoneAxe;
            case ItemType.IronAxe:return ItemAssets.Instance.IronAxe;
            case ItemType.AmatiteAxe:return ItemAssets.Instance.AmatiteAxe;
            case ItemType.StoneSickle:return ItemAssets.Instance.StoneSickle;
            case ItemType.IronSickle:return ItemAssets.Instance.IronSickle;
            case ItemType.AmatiteSickle: return ItemAssets.Instance.AmatiteSickle;
                //Materials

                //Herbs
            case ItemType.Melom: return ItemAssets.Instance.Melom;
            case ItemType.MellowMint: return ItemAssets.Instance.MellowMint;
            case ItemType.WaterHerb: return ItemAssets.Instance.WaterHerb;

                //Ores
            case ItemType.Stone: return ItemAssets.Instance.Stone;
            case ItemType.IronOre: return ItemAssets.Instance.IronOre;
            case ItemType.AmatiteOre: return ItemAssets.Instance.AmatiteOre;

                //Wood
            case ItemType.Oak: return ItemAssets.Instance.Oak;
            case ItemType.Pine: return ItemAssets.Instance.Pine;
            case ItemType.Redwood: return ItemAssets.Instance.Redwood;
        }
    }

    public CharacterEquipment.EquipSlot GetEquipSlot()
    {
        switch (itemType)
        {
            default:
                return CharacterEquipment.EquipSlot.UnEquipable;
            case ItemType.StonePickaxe:
            case ItemType.IronPickaxe:
            case ItemType.AmatitePickaxe:
                return CharacterEquipment.EquipSlot.Pickaxe;
            case ItemType.StoneAxe:
            case ItemType.IronAxe:
            case ItemType.AmatiteAxe:
                return CharacterEquipment.EquipSlot.Axe;
            case ItemType.StoneSickle:
            case ItemType.IronSickle:
            case ItemType.AmatiteSickle:
                return CharacterEquipment.EquipSlot.Sickle;

        }
    }

    public float GetTier()
    {
        return GetTier(itemType);
    }
    public static float GetTier(ItemType itemType)
    {
        //Higher tiers = higher level
        switch (itemType)
        {
            default:
                return 0;
            case ItemType.StonePickaxe:
            case ItemType.StoneAxe:
            case ItemType.StoneSickle:
            case ItemType.Melom:
                return 1;
            case ItemType.IronPickaxe:
            case ItemType.IronAxe:
            case ItemType.IronSickle:
            case ItemType.MellowMint:
                return 2;
            case ItemType.AmatitePickaxe:
            case ItemType.AmatiteAxe:
            case ItemType.AmatiteSickle:
            case ItemType.WaterHerb:
                return 3;
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
            default: 
                return false;

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

    public Boolean IsHerb()
    {
        switch (itemType)
        {
            default: 
                return false;
            case ItemType.Melom:
            case ItemType.WaterHerb:
            case ItemType.MellowMint:
                return true;
        }
    }
    public Boolean IsOre()
    {
        switch (itemType)
        {
            default: 
                return false;

            case ItemType.Stone:
            case ItemType.IronOre:
            case ItemType.AmatiteOre:
                return true;
        }
    }
    public Boolean IsWood()
    {
        switch (itemType)
        {
            default:
                return false;

            case ItemType.Oak:
            case ItemType.Pine:
            case ItemType.Redwood:
                return true;
        }
    }
    public override string ToString()
    {
        return itemType.ToString();
    }

    

}
