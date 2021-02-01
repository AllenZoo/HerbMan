using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem: MonoBehaviour
{
    //public EventHandler OnMaterialChanged;


    //private Player player;

    //private ItemOld herb;
    //private ItemOld ore;
    //private ItemOld wood;
    //private ItemOld energyShard;
    //private ItemOld recipe;
    //private ItemOld output;
    //public enum MaterialSlot 
    //{
    //    NonCraftable,
    //    Herb,
    //    Ore,
    //    Wood,
    //    EnergyShard,
    //    Recipe,
    //}

    //private void Awake()
    //{
    //    player = GetComponent<Player>();
    //}
    
    //public ItemOld CraftRecipeItem(ItemOld herb, ItemOld ore, ItemOld wood, ItemOld recipe) {

    //    ItemOld craftedItem = new ItemOld { itemType = ItemOld.ItemType.Null, count = 1, system = ItemOld.SystemType.craftedItem};

    //    /** Material Tier list:
    //     * (0)Hemm, Flint, Stick
    //     * (1)Melom, Stone, Oak
    //     * (2)MellowMint, IronOre, Pine
    //     * (3)WaterHerb, AmatiteOre, Redwood
    //     **/
        
    //    //Stone Pickaxe
    //    if (recipe.itemType == ItemOld.ItemType.Stone_Pickaxe_Recipe
    //     && herb.GetTier() == 0 && herb.count >= 1
    //      && ore.GetTier() == 0 &&  ore.count >= 2
    //     && wood.GetTier() == 0 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Stone_Pickaxe, count = 1, durability = 100, system = ItemOld.SystemType.craftedItem };
    //        DecreaseHerbAmount(1);
    //        DecreaseOreAmount(2);
    //        DecreaseWoodAmount(1);
    //        DecreaseRecipeAmount(1);
    //    }
    //    //Stone Axe
    //    else if (recipe.itemType == ItemOld.ItemType.Stone_Axe_Recipe
    //     && herb.GetTier() == 0 && herb.count >= 1
    //      && ore.GetTier() == 0 &&  ore.count >= 1
    //     && wood.GetTier() == 0 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Stone_Axe, count = 1, durability = 100 };
    //    }

    //    //Stone Sickle
    //    else if (recipe.itemType == ItemOld.ItemType.Stone_Sickle_Recipe
    //     && herb.GetTier() == 0 && herb.count >= 1
    //      && ore.GetTier() == 0 &&  ore.count >= 1
    //     && wood.GetTier() == 0 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Stone_Sickle, count = 1, durability = 100 };
    //    }

    //    //Iron Pickaxe
    //    else if (recipe.itemType == ItemOld.ItemType.Iron_Pickaxe_Recipe
    //     && herb.GetTier() == 1 && herb.count >= 1
    //      && ore.GetTier() == 1 &&  ore.count >= 1
    //     && wood.GetTier() == 1 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Iron_Pickaxe, count = 1, durability = 100 };
    //    }

    //    //Iron Axe
    //    else if (recipe.itemType == ItemOld.ItemType.Iron_Axe_Recipe
    //     && herb.GetTier() == 1 && herb.count >= 1
    //      && ore.GetTier() == 1 &&  ore.count >= 1
    //     && wood.GetTier() == 1 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Iron_Axe, count = 1, durability = 100 };
    //    }

    //    //Iron Sickle
    //    else if (recipe.itemType == ItemOld.ItemType.Iron_Sickle_Recipe
    //     && herb.GetTier() == 1 && herb.count >= 1
    //      && ore.GetTier() == 1 &&  ore.count >= 1
    //     && wood.GetTier() == 1 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Iron_Sickle, count = 1, durability = 100 };
    //    }

    //    //Amatite Pickaxe
    //    else if (recipe.itemType == ItemOld.ItemType.Amatite_Pickaxe_Recipe
    //     && herb.GetTier() == 2 && herb.count >= 1
    //      && ore.GetTier() == 2 &&  ore.count >= 1
    //     && wood.GetTier() == 2 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Amatite_Pickaxe, count = 1, durability = 100 };
    //    }

    //    //Amatite Axe
    //    else if (recipe.itemType == ItemOld.ItemType.Amatite_Axe_Recipe
    //     && herb.GetTier() == 2 && herb.count >= 1
    //      && ore.GetTier() == 2 &&  ore.count >= 1
    //     && wood.GetTier() == 2 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Amatite_Axe, count = 1, durability = 100 };
    //    }

    //    //Amatite Sickle
    //    else if (recipe.itemType == ItemOld.ItemType.Amatite_Sickle_Recipe
    //     && herb.GetTier() == 2 && herb.count >= 1
    //      && ore.GetTier() == 2 &&  ore.count >= 1
    //     && wood.GetTier() == 2 && wood.count >= 1)
    //    {
    //        craftedItem = new ItemOld { itemType = ItemOld.ItemType.Amatite_Sickle, count = 1, durability = 100 };
    //    }

    //    Debug.Log("craftingSystem.cs : " + craftedItem.itemType.ToString());
    //    return craftedItem;
    //}
    //public ItemOld GetHerbItem()
    //{
    //    return herb;
    //}
    //public ItemOld GetOreItem()
    //{
    //    return ore;
    //}
    //public ItemOld GetWoodItem()
    //{
    //    return wood;
    //}
    //public ItemOld GetEnergyShardItem()
    //{
    //    return energyShard;
    //}
    //public ItemOld GetRecipeItem()
    //{
    //    return recipe;
    //}
    //public ItemOld GetOutputItem()
    //{
    //    return output;
    //}
    //public void SetHerbItem(ItemOld herb)
    //{
    //    this.herb = herb;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public void SetOreItem(ItemOld ore)
    //{
    //    this.ore = ore;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public void SetWoodItem(ItemOld wood)
    //{
    //    this.wood = wood;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public void SetEnergyShardItem(ItemOld energyShard)
    //{
    //    this.energyShard = energyShard;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public void SetRecipeItem(ItemOld recipeItem)
    //{
    //    recipe = recipeItem;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public void SetOutput(ItemOld output)
    //{
    //    this.output = output;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void DecreaseHerbAmount(int count)
    //{
    //    herb.count -= count;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void DecreaseOreAmount(int count)
    //{
    //    ore.count -= count;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void DecreaseWoodAmount(int count)
    //{
    //    wood.count -= count;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void DecreaseEnergyShardAmount(int count)
    //{
    //    energyShard.count -= count;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void DecreaseRecipeAmount(int count)
    //{
    //    recipe.count -= count;
    //    OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public ItemOld GetSlotItem(MaterialSlot materialSlot)
    //{
    //    switch (materialSlot)
    //    {
    //        case MaterialSlot.Herb:
    //            return GetHerbItem();
    //        case MaterialSlot.Ore:
    //            return GetOreItem();
    //        case MaterialSlot.Wood:
    //            return GetWoodItem();
    //        case MaterialSlot.EnergyShard:
    //            return GetEnergyShardItem();
    //        case MaterialSlot.Recipe:
    //            return GetRecipeItem();
    //    }
    //    return null;
    //}
    //public void SetSlotItem(MaterialSlot materialSlot, ItemOld item)
    //{
    //    //failproof to check it slot and items are suitable
    //    if (item == null || materialSlot == item.GetMaterialSlot())
    //    {
    //        //if consistent would use switch(item.ItemType) but this is easier
    //        switch (materialSlot)
    //        {
    //            case MaterialSlot.Herb:
    //                SetHerbItem(item);
    //                break;
    //            case MaterialSlot.Ore:
    //                SetOreItem(item);
    //                break;
    //            case MaterialSlot.Wood:
    //                SetWoodItem(item);
    //                break;
    //            case MaterialSlot.EnergyShard:
    //                SetEnergyShardItem(item);
    //                break;
    //            case MaterialSlot.Recipe:
    //                SetRecipeItem(item);
    //                break;
    //        }
    //    }
    //}
    //public bool IsSuitableSlot(MaterialSlot materialSlot, ItemOld item)
    //{
    //    return materialSlot == item.GetMaterialSlot();
    //}
}
