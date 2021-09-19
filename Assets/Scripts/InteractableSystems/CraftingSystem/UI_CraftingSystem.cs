﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    //[SerializeField] private Transform pfItemUI;

    //private Transform itemContainer;

    //private UI_CraftingSlot herbSlot;
    //private UI_CraftingSlot oreSlot;
    //private UI_CraftingSlot woodSlot;
    //private UI_CraftingSlot energyShardSlot;
    //private UI_CraftingSlot recipeSlot;

    //private UI_OutputSlot outputSlot;

    //private CraftingSystem craftingSystem;
    //private InventoryOld inventory;

    //private void Awake()
    //{
    //    FindObjectOfType<GM_Initializer>().GetComponent<GM_Initializer>().SetUICraftingSystem(this);
    //    FindObjectOfType<UI_Manager>().GetComponent<UI_Manager>().SetUICraftingSystem(this.gameObject.transform);

    //    itemContainer = transform.Find("itemContainer");

    //    herbSlot = transform.Find("herbSlot").GetComponent<UI_CraftingSlot>();
    //    oreSlot = transform.Find("oreSlot").GetComponent<UI_CraftingSlot>();
    //    woodSlot = transform.Find("woodSlot").GetComponent<UI_CraftingSlot>();
    //    energyShardSlot = transform.Find("energyShardSlot").GetComponent<UI_CraftingSlot>();
    //    recipeSlot = transform.Find("recipeSlot").GetComponent<UI_CraftingSlot>();

    //    outputSlot = transform.Find("outputSlot").GetComponent<UI_OutputSlot>();

    //    herbSlot.OnItemDropped += HerbSlot_OnItemDropped;
    //    oreSlot.OnItemDropped += OreSlot_OnItemDropped;
    //    woodSlot.OnItemDropped += WoodSlot_OnItemDropped;
    //    energyShardSlot.OnItemDropped += EnergyShardSlot_OnItemDropped;
    //    recipeSlot.OnItemDropped += RecipeSlot_OnItemDropped;

    //    outputSlot.OnItemCrafted += OutputSlot_OnItemCrafted;

    //}

    //private void Start()
    //{


    //}

    //public void SetCraftingSystem(CraftingSystem craftingSystem)
    //{
    //    this.craftingSystem = craftingSystem;
    //    UpdateVisual();

    //    craftingSystem.OnMaterialChanged += CraftingSystem_OnMaterialChanged;
    //}
    //public void SetInventory(InventoryOld inventory)
    //{
    //    this.inventory = inventory;
    //}

    //public void Craft()
    //{
    //    ItemOld herb = craftingSystem.GetHerbItem();
    //    ItemOld ore = craftingSystem.GetOreItem();
    //    ItemOld wood = craftingSystem.GetWoodItem();
    //    ItemOld recipe = craftingSystem.GetRecipeItem();
    //    ItemOld energyShard = craftingSystem.GetEnergyShardItem();

    //    //Check if crafting slots are filled up
    //    if (herb != null && ore != null && wood != null)
    //    {
    //        ItemOld item = craftingSystem.CraftRecipeItem(herb, ore, wood, recipe);
    //        if (item.itemType != ItemOld.ItemType.Null)
    //        {
    //            item.system = ItemOld.SystemType.craftedItem;
    //            craftingSystem.SetOutput(item);
    //            outputSlot.OnItemCrafted?.Invoke(this, new UI_OutputSlot.OnItemCraftedEventArgs { item = item });
    //        }
    //        else
    //        {
    //            Debug.Log("Not possible to craft");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Not possible to craft");
    //    }
        
    //}

    //private void CraftingSystem_OnMaterialChanged(object sender, EventArgs e)
    //{
    //    UpdateVisual();
    //}

    //private void HerbSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    //{
    //    TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Herb, e.item);
    //}
    //private void OreSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    //{
    //    TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Ore, e.item);
    //}
    //private void WoodSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    //{
    //    TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Wood, e.item);
    //}
    //private void EnergyShardSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    //{
    //    TryDropMaterialInSlot(CraftingSystem.MaterialSlot.EnergyShard, e.item);
    //}
    //private void RecipeSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    //{
    //    TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Recipe, e.item);
    //}

    //private void OutputSlot_OnItemCrafted(object sender, UI_OutputSlot.OnItemCraftedEventArgs e)
    //{
    //    RefreshOutputSlot();
    //}

    //private void UpdateVisual()
    //{
    //    foreach(Transform child in itemContainer)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    ItemOld herbItem = craftingSystem.GetHerbItem();
    //    ItemOld oreItem = craftingSystem.GetOreItem();
    //    ItemOld woodItem = craftingSystem.GetWoodItem();
    //    ItemOld energyShardItem = craftingSystem.GetEnergyShardItem();
    //    ItemOld recipeItem = craftingSystem.GetRecipeItem();

    //    if (herbItem?.count == 0)
    //    {
            
    //        craftingSystem.SetHerbItem(null);
    //    }
    //    if (oreItem?.count == 0)
    //    {
           
    //        craftingSystem.SetOreItem(null);
    //    }
    //    if (woodItem?.count == 0)
    //    {
           
    //        craftingSystem.SetWoodItem(null);
    //    }
    //    if (recipeItem?.count == 0)
    //    {
            
    //        craftingSystem.SetRecipeItem(null);
    //    }

    //    RefreshCraftingSlot(herbSlot, herbItem);
    //    RefreshCraftingSlot(oreSlot, oreItem);
    //    RefreshCraftingSlot(woodSlot, woodItem);
    //    RefreshCraftingSlot(energyShardSlot, energyShardItem);
    //    RefreshCraftingSlot(recipeSlot, recipeItem);
    //    RefreshOutputSlot();

    //}
    
    //private void RefreshCraftingSlot(UI_CraftingSlot craftingSlot, ItemOld item)
    //{
    //    if(item != null)
    //    {
    //        Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
    //        uiItemTransform.GetComponent<RectTransform>().anchoredPosition = craftingSlot.GetComponent<RectTransform>().anchoredPosition;
    //        uiItemTransform.localScale = Vector3.one * 1f;
    //        uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = true;

    //        UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
    //        uiItem.SetItem(item);
    //        uiItem.SetCount(item.count);
    //        uiItem.RefreshCountText();

    //        craftingSlot.transform.Find("itemSlot").gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        craftingSlot.transform.Find("itemSlot").gameObject.SetActive(true);
    //    }
    //}
    //private void RefreshOutputSlot()
    //{
    //    ItemOld item = craftingSystem.GetOutputItem();
    //    if (item != null)
    //    {
    //        ItemOld tempItem = new ItemOld { itemType = item.itemType, count = item.count, durability = item.durability, system = ItemOld.SystemType.craftedItem };
    //        Debug.Log(tempItem.itemType.ToString());
    //        Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
    //        uiItemTransform.GetComponent<RectTransform>().anchoredPosition = outputSlot.GetComponent<RectTransform>().anchoredPosition;
    //        uiItemTransform.localScale = Vector3.one * 1f;
    //        uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = true;

    //        UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
    //        uiItem.SetItem(tempItem);
    //        uiItem.SetCount(tempItem.count);
            
    //        uiItem.RefreshCountText();

    //        outputSlot.transform.Find("itemSlot").gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        outputSlot.transform.Find("itemSlot").gameObject.SetActive(true);
    //    }
    
    //}
    //private void RefreshOutputSlot(ItemOld item)
    //{
    //    if(item != null)
    //    {
    //        ItemOld tempItem = new ItemOld { itemType = item.itemType, count = item.count, durability = item.durability, system = ItemOld.SystemType.equipment };

    //        Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
    //        uiItemTransform.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
    //        uiItemTransform.localScale = Vector3.one * 1f;
    //        uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = true;

    //        UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
    //        uiItem.SetItem(tempItem);
    //        uiItem.SetCount(tempItem.count);
    //        uiItem.RefreshCountText();

    //        outputSlot.transform.Find("itemSlot").gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        outputSlot.transform.Find("itemSlot").gameObject.SetActive(true);
    //    }
    //}
    //private void TryDropMaterialInSlot(CraftingSystem.MaterialSlot materialSlot, ItemOld item)
    //{
    //    //Item dropped into material slot, check if slot and item are suitble.
    //    if(craftingSystem.IsSuitableSlot(materialSlot, item))
    //    {
    //        //Check if slot is empty
    //        if(craftingSystem.GetSlotItem(materialSlot) == null)
    //        {
    //            //Move item from inventory to slot
    //            ItemOld tempItem = new ItemOld { itemType = item.itemType, count = item.count, durability = item.durability, system = ItemOld.SystemType.crafting };
    //            craftingSystem.SetSlotItem(materialSlot, tempItem);
    //            inventory.RemoveItem(item);
    //            UI_ItemDrag.Instance.Hide();
    //        }
    //        else
    //        {
    //            //Item is present in slot, therefore switch items
    //            ItemOld tempItemInCraftingSlot = craftingSystem.GetSlotItem(materialSlot);
    //            ItemOld tempItemForCraftingSlot = new ItemOld { itemType = item.itemType, count = item.count, durability = item.durability, system = ItemOld.SystemType.crafting };

    //            //Move item from inventory to crafting slot
    //            craftingSystem.SetSlotItem(materialSlot, tempItemForCraftingSlot);
    //            inventory.RemoveItem(item);

    //            //Move item from crafting slot to inventory
    //            inventory.AddItem(tempItemInCraftingSlot);
    //            UI_ItemDrag.Instance.Hide();
    //        }
    //    }
    //    UI_ItemDrag.Instance.Hide();
    //}
}