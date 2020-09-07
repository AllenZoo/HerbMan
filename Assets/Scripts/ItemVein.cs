using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemVein
{
    public enum ItemType
    {
        //Herbs
        Melom_V,
        WaterHerb_V,
        MellowMint_V,

        //Ores
        Stone_V,
        IronOre_V,
        AmatiteOre_V,

        //Trees
        Oak_V,
        Pine_V,
        Redwood_V,
    }

    public Item item;
    public ItemType itemType;
    public float harvestTime;
    public int animPhase;

    public RuntimeAnimatorController rtAnimatorController;

    public Sprite GetSprite()
    {
        return GetSprite(itemType);
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Melom_V: return ItemAssets.Instance.MelomVein;
            case ItemType.WaterHerb_V: return ItemAssets.Instance.WaterHerbVein;
            case ItemType.MellowMint_V: return ItemAssets.Instance.MellowMintVein;
            case ItemType.Stone_V: return ItemAssets.Instance.StoneVein;
            case ItemType.IronOre_V: return ItemAssets.Instance.IronOreVein;
            case ItemType.AmatiteOre_V: return ItemAssets.Instance.AmatiteOreVein;
            case ItemType.Oak_V: return ItemAssets.Instance.OakVein;
            case ItemType.Pine_V: return ItemAssets.Instance.PineVein;
            case ItemType.Redwood_V: return ItemAssets.Instance.RedwoodVein;
        }
    }
    public String GetVeinName(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Melom_V: return "Melom_V";
        }
    }

    public int GetAnimPhases()
    {
        //Phases starts at 0
        return animPhase - 1;
    }
    public void DecreaseCount(int amount)
    {
        item.count -= amount;
    }
    public void AddCount(int amount)
    {
        item.count += amount;
    }
    public float GetHarvestTime()
    {
        return harvestTime;
    }
    public Item GetItem()
    {
        return item;
    }
    public RuntimeAnimatorController GetRuntimeAnimatorController()
    {
        return rtAnimatorController;
    }
}

