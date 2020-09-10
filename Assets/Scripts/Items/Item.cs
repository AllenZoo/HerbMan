using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    /**Instructions for adding new items 
     * 
     * TOOLS
     * 
     * 
     * MATERIALS
     * -enum ItemType
     * -ItemAssets.Instance (Create public Sprite -item_name- in ItemAssets.cs)
     * -GetSprite()
     * -GetTier()
     * -IsStackable()
     * -IsMaterial()
     * -IsHerb(), IsOre(), IsWood()
     * 
     * -Add Sprites to ItemAssets Prefab
     * 
     * IMPORTANT! ADD NEW ITEMTYPES TO BOTTOM OF LIST
     * **/
    public enum ItemType
    {
        Null,
        //Tools
        Stone_Pickaxe,
        Iron_Pickaxe,
        Amatite_Pickaxe,
        Stone_Axe,
        Iron_Axe,
        Amatite_Axe,
        Stone_Sickle,
        Iron_Sickle,
        Amatite_Sickle,

        //Herbs
        Hemm,
        Melom,
        WaterHerb,
        MellowMint,

        //Ores
        Flint,
        Stone,
        IronOre,
        AmatiteOre,

        //Wood
        Stick,
        Oak,
        Pine,
        Redwood,

        //Recipes
        Stone_Pickaxe_Recipe,
        Iron_Pickaxe_Recipe,
        Amatite_Pickaxe_Recipe,
        Stone_Axe_Recipe,
        Iron_Axe_Recipe,
        Amatite_Axe_Recipe,
        Stone_Sickle_Recipe,
        Iron_Sickle_Recipe,
        Amatite_Sickle_Recipe,
    }

    public ItemType itemType;
    public int count;
    public float durability;

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
            case ItemType.Stone_Pickaxe:return ItemAssets.Instance.StonePickaxe;
            case ItemType.Iron_Pickaxe:return ItemAssets.Instance.IronPickaxe;
            case ItemType.Amatite_Pickaxe:return ItemAssets.Instance.AmatitePickaxe;
            case ItemType.Stone_Axe:return ItemAssets.Instance.StoneAxe;
            case ItemType.Iron_Axe:return ItemAssets.Instance.IronAxe;
            case ItemType.Amatite_Axe:return ItemAssets.Instance.AmatiteAxe;
            case ItemType.Stone_Sickle:return ItemAssets.Instance.StoneSickle;
            case ItemType.Iron_Sickle:return ItemAssets.Instance.IronSickle;
            case ItemType.Amatite_Sickle: return ItemAssets.Instance.AmatiteSickle;
            //Materials

            //Herbs
            case ItemType.Hemm: return ItemAssets.Instance.Hemm;
            case ItemType.Melom: return ItemAssets.Instance.Melom;
            case ItemType.MellowMint: return ItemAssets.Instance.MellowMint;
            case ItemType.WaterHerb: return ItemAssets.Instance.WaterHerb;

            //Ores
            case ItemType.Flint: return ItemAssets.Instance.Flint;
            case ItemType.Stone: return ItemAssets.Instance.Stone;
            case ItemType.IronOre: return ItemAssets.Instance.IronOre;
            case ItemType.AmatiteOre: return ItemAssets.Instance.AmatiteOre;

            //Wood
            case ItemType.Stick: return ItemAssets.Instance.Stick;
            case ItemType.Oak: return ItemAssets.Instance.Oak;
            case ItemType.Pine: return ItemAssets.Instance.Pine;
            case ItemType.Redwood: return ItemAssets.Instance.Redwood;

            //Recipes
            case ItemType.Stone_Pickaxe_Recipe: return ItemAssets.Instance.StonePickaxeRecipe;
            case ItemType.Iron_Pickaxe_Recipe: return ItemAssets.Instance.IronPickaxeRecipe;
            case ItemType.Amatite_Pickaxe_Recipe: return ItemAssets.Instance.AmatitePickaxeRecipe;
            case ItemType.Stone_Axe_Recipe: return ItemAssets.Instance.StoneAxeRecipe;
            case ItemType.Iron_Axe_Recipe: return ItemAssets.Instance.IronAxeRecipe;
            case ItemType.Amatite_Axe_Recipe: return ItemAssets.Instance.AmatiteAxeRecipe;
            case ItemType.Stone_Sickle_Recipe: return ItemAssets.Instance.StoneSickleRecipe;
            case ItemType.Iron_Sickle_Recipe: return ItemAssets.Instance.IronSickleRecipe;
            case ItemType.Amatite_Sickle_Recipe: return ItemAssets.Instance.AmatiteSickleRecipe;
        }
    }

    public CharacterEquipment.EquipSlot GetEquipSlot()
    {
        switch (itemType)
        {
            default:
                return CharacterEquipment.EquipSlot.UnEquipable;
            case ItemType.Stone_Pickaxe:
            case ItemType.Iron_Pickaxe:
            case ItemType.Amatite_Pickaxe:
                return CharacterEquipment.EquipSlot.Pickaxe;
            case ItemType.Stone_Axe:
            case ItemType.Iron_Axe:
            case ItemType.Amatite_Axe:
                return CharacterEquipment.EquipSlot.Axe;
            case ItemType.Stone_Sickle:
            case ItemType.Iron_Sickle:
            case ItemType.Amatite_Sickle:
                return CharacterEquipment.EquipSlot.Sickle;

        }
    }

    public CraftingSystem.MaterialSlot GetMaterialSlot()
    {
        switch (itemType)
        {
            default:
                return CraftingSystem.MaterialSlot.NonCraftable;
            case ItemType.Hemm:
            case ItemType.Melom:
            case ItemType.MellowMint:
            case ItemType.WaterHerb:
                return CraftingSystem.MaterialSlot.Herb;
            case ItemType.Flint:
            case ItemType.Stone:
            case ItemType.IronOre:
            case ItemType.AmatiteOre:
                return CraftingSystem.MaterialSlot.Ore;
            case ItemType.Stick:
            case ItemType.Oak:
            case ItemType.Pine:
            case ItemType.Redwood:
                return CraftingSystem.MaterialSlot.Wood;
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
            case ItemType.Stick:
            case ItemType.Flint:
            case ItemType.Hemm:
                return 0;
            case ItemType.Stone_Pickaxe:
            case ItemType.Stone_Axe:
            case ItemType.Stone_Sickle:
            case ItemType.Melom:
                return 1;
            case ItemType.Iron_Pickaxe:
            case ItemType.Iron_Axe:
            case ItemType.Iron_Sickle:
            case ItemType.MellowMint:
                return 2;
            case ItemType.Amatite_Pickaxe:
            case ItemType.Amatite_Axe:
            case ItemType.Amatite_Sickle:
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
            case ItemType.Stone_Pickaxe:
            case ItemType.Iron_Pickaxe:
            case ItemType.Amatite_Pickaxe:
            case ItemType.Stone_Axe:
            case ItemType.Iron_Axe:
            case ItemType.Amatite_Axe:
            case ItemType.Stone_Sickle:
            case ItemType.Iron_Sickle:
            case ItemType.Amatite_Sickle:return false;

            //Materials

            //Herbs
            case ItemType.Hemm:
            case ItemType.Melom:
            case ItemType.MellowMint:
            case ItemType.WaterHerb:

            //Ores
            case ItemType.Flint:
            case ItemType.Stone:
            case ItemType.IronOre:
            case ItemType.AmatiteOre:

            //Wood
            case ItemType.Stick:
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
            case ItemType.Stone_Pickaxe:
            case ItemType.Iron_Pickaxe:
            case ItemType.Amatite_Pickaxe:
            case ItemType.Stone_Axe:
            case ItemType.Iron_Axe:
            case ItemType.Amatite_Axe:
            case ItemType.Stone_Sickle:
            case ItemType.Iron_Sickle:
            case ItemType.Amatite_Sickle: return true;
        }
    }

    public Boolean IsMaterial()
    {
        switch (itemType)
        {
            default: 
                return false;

            //Herbs
            case ItemType.Hemm:
            case ItemType.Melom:
            case ItemType.WaterHerb:
            case ItemType.MellowMint:

            //Ores
            case ItemType.Flint:
            case ItemType.Stone:
            case ItemType.IronOre:
            case ItemType.AmatiteOre:

            //Trees
            case ItemType.Stick:
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
            case ItemType.Hemm:
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
            case ItemType.Flint:
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

            case ItemType.Stick:
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
