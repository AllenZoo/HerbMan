using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem: MonoBehaviour
{
    public EventHandler OnMaterialChanged;
    public EventHandler OnItemCrafted;

    private Player player;

    private Item herb;
    private Item ore;
    private Item wood;
    private Item energyShard;
    private Item recipe;

    private OutputSlot outputSlot;
    public enum MaterialSlot 
    {
        NonCraftable,
        Herb,
        Ore,
        Wood,
        EnergyShard,
        Recipe,
    }

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    public Item Craft()
    {
        //Check if crafting slots are filled up
        if(herb != null && ore != null && wood != null)
        {
            Debug.Log("H: " + herb.ToString() + " O: " + ore.ToString() + " W: " + wood.ToString());
            if(CraftRecipeItem(herb, ore, wood).itemType != Item.ItemType.Null)
            {
                OnItemCrafted?.Invoke(this, EventArgs.Empty);
            }
            return CraftRecipeItem(herb, ore, wood);
        }
        return null;
    }
    public Item CraftRecipeItem(Item herb, Item ore, Item wood) {
        Item craftedItem = new Item { itemType = Item.ItemType.Null, count = 1};

        if (herb.itemType == Item.ItemType.Hemm
        && ore.itemType == Item.ItemType.Flint
        && wood.itemType == Item.ItemType.Stick)
        {
            //Maybe add in future a "TOME" which contains crafting options for Stone tools and etc.
            craftedItem.itemType = Item.ItemType.Stone_Sickle;
        }

        else if (herb.itemType == Item.ItemType.Melom
        && ore.itemType == Item.ItemType.Stone
        && wood.itemType == Item.ItemType.Oak)
        {
            craftedItem.itemType = Item.ItemType.Iron_Sickle;
        }

        else if (herb.itemType == Item.ItemType.MellowMint
        && ore.itemType == Item.ItemType.IronOre
        && wood.itemType == Item.ItemType.Pine)
        {
            craftedItem.itemType = Item.ItemType.Amatite_Sickle;
        }

        else if (herb.itemType == Item.ItemType.WaterHerb
            && ore.itemType == Item.ItemType.AmatiteOre
            && wood.itemType == Item.ItemType.Redwood)
        {
            craftedItem.itemType = Item.ItemType.Stone_Axe;
        }
        return craftedItem;
    }
    public Item GetHerbItem()
    {
        return herb;
    }
    public Item GetOreItem()
    {
        return ore;
    }
    public Item GetWoodItem()
    {
        return wood;
    }
    public Item GetEnergyShardItem()
    {
        return energyShard;
    }
    public Item GetRecipeItem()
    {
        return recipe;
    }
    public void SetHerbItem(Item herb)
    {
        this.herb = herb;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetOreItem(Item ore)
    {
        this.ore = ore;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetWoodItem(Item wood)
    {
        this.wood = wood;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetEnergyShardItem(Item energyShard)
    {
        this.energyShard = energyShard;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetRecipeItem(Item recipeItem)
    {
        recipe = recipeItem;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetOutput(Item output)
    {
        outputSlot.SetOutputItem(output);
    }
    public Item GetSlotItem(MaterialSlot materialSlot)
    {
        switch (materialSlot)
        {
            case MaterialSlot.Herb:
                return GetHerbItem();
            case MaterialSlot.Ore:
                return GetOreItem();
            case MaterialSlot.Wood:
                return GetWoodItem();
            case MaterialSlot.EnergyShard:
                return GetEnergyShardItem();
            case MaterialSlot.Recipe:
                return GetRecipeItem();
        }
        return null;
    }
    public void SetSlotItem(MaterialSlot materialSlot, Item item)
    {
        //failproof to check it slot and items are suitable
        if (materialSlot == item.GetMaterialSlot())
        {
            //if consistent would use switch(item.ItemType) but this is easier
            switch (materialSlot)
            {
                case MaterialSlot.Herb:
                    SetHerbItem(item);
                    break;
                case MaterialSlot.Ore:
                    SetOreItem(item);
                    break;
                case MaterialSlot.Wood:
                    SetWoodItem(item);
                    break;
                case MaterialSlot.EnergyShard:
                    SetEnergyShardItem(item);
                    break;
                case MaterialSlot.Recipe:
                    SetRecipeItem(item);
                    break;
            }
        }
    }
    public bool IsSuitableSlot(MaterialSlot materialSlot, Item item)
    {
        return materialSlot == item.GetMaterialSlot();
    }
}
