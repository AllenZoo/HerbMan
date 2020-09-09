using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public static Recipe Instance { get; private set; }

    private Item herb;
    private Item ore;
    private Item wood;
    private Item energyShard;

    //public Item CraftRecipeItem()
    //{
    //    return CraftRecipeItem(herb, ore, wood, energyShard);
    //}

    public Item CraftRecipeItem(Item herb, Item ore, Item wood)
    {
        Item craftedItem = null;

        if(herb.itemType == Item.ItemType.Hemm
        && ore.itemType == Item.ItemType.Flint
        && wood.itemType == Item.ItemType.Stick)
        {
            //Maybe add in future a "TOME" which contains crafting options for Stone tools and etc.
            craftedItem.itemType = Item.ItemType.StoneSickle;
        }

        else if (herb.itemType == Item.ItemType.Melom
        && ore.itemType == Item.ItemType.Stone
        && wood.itemType == Item.ItemType.Oak)
        {
            craftedItem.itemType = Item.ItemType.IronSickle;
        }

        else if (herb.itemType == Item.ItemType.MellowMint
        && ore.itemType == Item.ItemType.IronOre
        && wood.itemType == Item.ItemType.Pine)
        {
            craftedItem.itemType = Item.ItemType.AmatiteSickle;
        }

        else if (herb.itemType == Item.ItemType.WaterHerb
            && ore.itemType == Item.ItemType.AmatiteOre
            && wood.itemType == Item.ItemType.Redwood)
        {
            craftedItem.itemType = Item.ItemType.StoneAxe;
        }
        /**Recipe Format
         * 
            else if (herb.itemType == Item.ItemType.Hemm
            && ore.itemType == Item.ItemType.Flint
            && wood.itemType == Item.ItemType.Stick)
            {
            craftedItem.itemType = Item.ItemType.StoneAxe;
            }
        **/
        return craftedItem;
    }
    public Item EnchantCraftedItem(Item energyShard)
    {
        if (energyShard.count != 0 && energyShard != null)
        {
            //Enchant(energyShard.count);
        }
        return null;
    }
}
