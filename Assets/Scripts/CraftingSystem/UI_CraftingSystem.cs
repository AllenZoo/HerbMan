using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfItemUI;

    private Transform itemContainer;

    private UI_CraftingSlot herbSlot;
    private UI_CraftingSlot oreSlot;
    private UI_CraftingSlot woodSlot;
    private UI_CraftingSlot energyShardSlot;
    private UI_CraftingSlot recipeSlot;

    private OutputSlot outputSlot;

    private CraftingSystem craftingSystem;
    private Inventory inventory;

    private void Awake()
    {
        itemContainer = transform.Find("itemContainer");

        herbSlot = transform.Find("herbSlot").GetComponent<UI_CraftingSlot>();
        oreSlot = transform.Find("oreSlot").GetComponent<UI_CraftingSlot>();
        woodSlot = transform.Find("woodSlot").GetComponent<UI_CraftingSlot>();
        energyShardSlot = transform.Find("energyShardSlot").GetComponent<UI_CraftingSlot>();
        recipeSlot = transform.Find("recipeSlot").GetComponent<UI_CraftingSlot>();

        outputSlot = transform.Find("outputSlot").GetComponent<OutputSlot>();

        herbSlot.OnItemDropped += HerbSlot_OnItemDropped;
        oreSlot.OnItemDropped += OreSlot_OnItemDropped;
        woodSlot.OnItemDropped += WoodSlot_OnItemDropped;
        energyShardSlot.OnItemDropped += EnergyShardSlot_OnItemDropped;
        recipeSlot.OnItemDropped += RecipeSlot_OnItemDropped;
    }

    

    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
        UpdateVisual();

        craftingSystem.OnMaterialChanged += CraftingSystem_OnMaterialChanged;
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void Craft()
    {
        outputSlot.SetOutputItem(craftingSystem.Craft());
        Debug.Log("Crafted: " + craftingSystem.Craft().ToString());
    }

    private void CraftingSystem_OnMaterialChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void HerbSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Herb, e.item);
    }
    private void OreSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Ore, e.item);
    }
    private void WoodSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Wood, e.item);
    }
    private void EnergyShardSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        TryDropMaterialInSlot(CraftingSystem.MaterialSlot.EnergyShard, e.item);
    }
    private void RecipeSlot_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        TryDropMaterialInSlot(CraftingSystem.MaterialSlot.Recipe, e.item);
    }
    private void UpdateVisual()
    {
        foreach(Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        Item herbItem = craftingSystem.GetHerbItem();
        Item oreItem = craftingSystem.GetOreItem();
        Item woodItem = craftingSystem.GetWoodItem();
        Item energyShardItem = craftingSystem.GetEnergyShardItem();
        Item recipeItem = craftingSystem.GetRecipeItem();

        RefreshCraftingSlot(herbSlot, herbItem);
        RefreshCraftingSlot(oreSlot, oreItem);
        RefreshCraftingSlot(woodSlot, woodItem);
        RefreshCraftingSlot(energyShardSlot, energyShardItem);
        RefreshCraftingSlot(recipeSlot, recipeItem);

    }
    
    private void RefreshCraftingSlot(UI_CraftingSlot craftingSlot, Item item)
    {
        if(item != null)
        {
            Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = craftingSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = false;

            UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
            uiItem.SetItem(item);
            uiItem.SetCount(item.count);
            uiItem.RefreshCountText();

            craftingSlot.transform.Find("itemSlot").gameObject.SetActive(false);
        }
        else
        {
            craftingSlot.transform.Find("itemSlot").gameObject.SetActive(true);
        }
    }

    private void TryDropMaterialInSlot(CraftingSystem.MaterialSlot materialSlot, Item item)
    {
        //Item dropped into material slot, check if slot and item are suitble.
        if(craftingSystem.IsSuitableSlot(materialSlot, item))
        {
            //Check if slot is empty
            if(craftingSystem.GetSlotItem(materialSlot) == null)
            {
                //Move item from inventory to slot
                Item tempItem = new Item { itemType = item.itemType, count = item.count, durability = item.durability };
                craftingSystem.SetSlotItem(materialSlot, tempItem);
                inventory.RemoveItem(item);
                UI_ItemDrag.Instance.Hide();
            }
            else
            {
                //Item is present in slot, therefore switch items
                Item tempItemInCraftingSlot = craftingSystem.GetSlotItem(materialSlot);

                Item tempItemForCraftingSlot = new Item { itemType = item.itemType, count = item.count, durability = item.durability };
                craftingSystem.SetSlotItem(materialSlot, tempItemForCraftingSlot);
                inventory.RemoveItem(item);
                inventory.AddItem(tempItemInCraftingSlot);
                UI_ItemDrag.Instance.Hide();
            }
        }
        UI_ItemDrag.Instance.Hide();
    }
}
