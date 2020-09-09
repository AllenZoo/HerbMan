using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{ 
    [SerializeField] private Transform hiddenArea;

    [Header("Crafting System")]
    [SerializeField] private Transform uiCraftingSystem;
    [SerializeField] private Transform uiCraftingArea;

    [Header("Equipment Slots")]
    [SerializeField] private Transform uiEquipmentSlots;
    [SerializeField] private Transform uiEquipmentSlotArea;

    [Header("Inventory")]
    [SerializeField] private Transform uiInventory;
    [SerializeField] private Transform uiInventoryArea;

    private void Start()
    {
        uiInventoryArea.transform.position = uiInventory.transform.position;
        uiCraftingArea.transform.position = uiCraftingSystem.transform.position;
        uiEquipmentSlotArea.transform.position = uiEquipmentSlots.transform.position;
    }

    public void CloseInventory()
    {
        uiInventory.transform.position = hiddenArea.transform.position;
    }
    public void OpenInventory()
    {
        uiInventory.transform.position = uiInventoryArea.transform.position;
    }

    public void CloseCraftingSystem()
    {
        uiCraftingSystem.transform.position = hiddenArea.transform.position;
    }
    public void OpenCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingArea.transform.position;
    }
    public void CloseEquipmentSlots()
    {
        uiEquipmentSlots.transform.position = hiddenArea.transform.position;
    }
    public void OpenEquipmentSlots()
    {
        uiEquipmentSlots.transform.position = uiEquipmentSlotArea.transform.position;
    }
}
