using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfItemUI;

    private Transform itemContainer;

    private CraftingSlot herbSlot;
    private CraftingSlot oreSlot;
    private CraftingSlot woodSlot;
    private CraftingSlot energyShardSlot;

    private OutputSlot outputSlot;

    private CraftingSystem craftingSystem;
    private Inventory inventory;

    private void Awake()
    {
        itemContainer = transform.Find("itemContainer");

        herbSlot = transform.Find("herbSlot").GetComponent<CraftingSlot>();
        oreSlot = transform.Find("oreSlot").GetComponent<CraftingSlot>();
        woodSlot = transform.Find("woodSlot").GetComponent<CraftingSlot>();
        energyShardSlot = transform.Find("energyShardSlot").GetComponent<CraftingSlot>();

        outputSlot = transform.Find("outputSlot").GetComponent<OutputSlot>();

        herbSlot.OnItemDropped += HerbSlot_OnItemDropped;
        oreSlot.OnItemDropped += OreSlot_OnItemDropped;
        woodSlot.OnItemDropped += WoodSlot_OnItemDropped;
        energyShardSlot.OnItemDropped += EnergyShardSlot_OnItemDropped;
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

    private void CraftingSystem_OnMaterialChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void HerbSlot_OnItemDropped(object sender, CraftingSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("dropped on herb slot!");
        craftingSystem.SetHerbItem(e.item);
    }
    private void OreSlot_OnItemDropped(object sender, CraftingSlot.OnItemDroppedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    private void WoodSlot_OnItemDropped(object sender, CraftingSlot.OnItemDroppedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EnergyShardSlot_OnItemDropped(object sender, CraftingSlot.OnItemDroppedEventArgs e)
    {
        throw new System.NotImplementedException();
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

        if(herbItem != null)
        {
            Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = herbSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = false;
            ItemUI uiItem = uiItemTransform.GetComponent<ItemUI>();
            uiItem.SetItem(herbItem);

            herbSlot.transform.Find("itemSlot").gameObject.SetActive(false);
        }
        else
        {
            herbSlot.transform.Find("itemSlot").gameObject.SetActive(true);
        }

    }
    

    
}
