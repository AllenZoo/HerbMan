using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject player;

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

    private bool inCraftingSystem;
    private bool inInventory;

    private void Start()
    {
        uiInventoryArea.transform.position = uiInventory.transform.position;
        uiCraftingArea.transform.position = uiCraftingSystem.transform.position;
        uiEquipmentSlotArea.transform.position = uiEquipmentSlots.transform.position;

        inCraftingSystem = true;
        inInventory = true;
    }

    public void CloseInventory()
    {
        uiInventory.transform.position = hiddenArea.transform.position;
        inInventory = false;
    }
    public void OpenInventory()
    {
        uiInventory.transform.position = uiInventoryArea.transform.position;
        inInventory = true;
    }

    public void CloseCraftingSystem()
    {
        uiCraftingSystem.transform.position = hiddenArea.transform.position;
        inCraftingSystem = false;
    }
    public void OpenCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingArea.transform.position;
        inCraftingSystem = true;
    }

    public void CloseEquipmentSlots()
    {
        uiEquipmentSlots.transform.position = hiddenArea.transform.position;
    }
    public void OpenEquipmentSlots()
    {
        uiEquipmentSlots.transform.position = uiEquipmentSlotArea.transform.position;
    }

    public bool PlayerCanMove()
    {
        return !inCraftingSystem && !inInventory;
    }

    private void Update()
    {
        if (PlayerCanMove())
        {
            player.GetComponent<Player_Movement>().enabled = true;
        }
        else
        {
            player.GetComponent<Player_Movement>().enabled = false;
        }
    }
}
