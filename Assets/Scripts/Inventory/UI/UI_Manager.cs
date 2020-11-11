using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Transform hiddenArea;

    [Header("Crafting System")]
    [SerializeField] private Transform uiCraftingSystem;
    [SerializeField] private Transform uiCraftingArea;
    [SerializeField] private Button openButtonCrafting;
    [SerializeField] private Button closeButtonCrafting;

    [Header("Equipment Slots")]
    [SerializeField] private Transform uiEquipmentSlots;
    [SerializeField] private Transform uiEquipmentSlotArea;

    [Header("Inventory")]
    [SerializeField] private Transform uiInventory;
    [SerializeField] private Transform uiInventoryArea;
    [SerializeField] private Button openButtonInventory;
    [SerializeField] private Button closeButtonInventory;

    private bool inCraftingSystem;
    private bool inInventory;

    private void Start()
    {
        uiInventoryArea.transform.position = uiInventory.transform.position;
        uiCraftingArea.transform.position = uiCraftingSystem.transform.position;
        uiEquipmentSlotArea.transform.position = uiEquipmentSlots.transform.position;

        inCraftingSystem = true;
        inInventory = true;

        //Closeing inventory and crafting system
        CloseInventory();
        CloseCraftingSystem();
    }

    public void CloseInventory()
    {
        uiInventory.transform.position = hiddenArea.transform.position;
        openButtonInventory.gameObject.SetActive(true);
        closeButtonInventory.gameObject.SetActive(false);

        inInventory = false;
    }
    public void OpenInventory()
    {
        uiInventory.transform.position = uiInventoryArea.transform.position;
        openButtonInventory.gameObject.SetActive(false);
        closeButtonInventory.gameObject.SetActive(true);

        inInventory = true;
    }

    public void CloseCraftingSystem()
    {
        uiCraftingSystem.transform.position = hiddenArea.transform.position;
        openButtonCrafting.gameObject.SetActive(true);
        closeButtonCrafting.gameObject.SetActive(false);

        inCraftingSystem = false;
    }
    public void OpenCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingArea.transform.position;
        openButtonCrafting.gameObject.SetActive(false);
        closeButtonCrafting.gameObject.SetActive(true);

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

            player.transform.Find("Orbiter").GetComponent<OrbitController>().enabled = true;
        }
        else
        {
            player.GetComponent<Player_Movement>().enabled = false;

            player.transform.Find("Orbiter").GetComponent<OrbitController>().enabled = false;
        }
    }
}
