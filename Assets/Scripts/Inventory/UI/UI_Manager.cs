using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Header("Crafting System")]
    [SerializeField] private Transform uiCraftingSystem;
    [SerializeField] private Button openButtonCrafting;
    [SerializeField] private Button closeButtonCrafting;

    [Header("Equipment Slots")]
    [SerializeField] private Transform uiEquipmentSlots;

    [Header("Inventory")]
    [SerializeField] private Transform uiInventory;
    [SerializeField] private Button openButtonInventory;
    [SerializeField] private Button closeButtonInventory;

    [Header("Trader Quests")]
    [SerializeField] private Transform uiTraderQuest;
    [SerializeField] private Button openButtonTQ;
    [SerializeField] private Button closeButtonTQ;

    private bool inCraftingSystem;
    private bool inInventory;

    private void Start()
    {
        inCraftingSystem = true;
        inInventory = true;

        //Closing inventory and crafting and quest systems
        CloseInventory();
        CloseCraftingSystem();
        CloseTraderQuestInterface();

        //Button Stuff
        openButtonInventory.onClick.AddListener(OpenInventory);
        closeButtonInventory.onClick.AddListener(CloseInventory);

        openButtonCrafting.onClick.AddListener(OpenCraftingSystem);
        closeButtonCrafting.onClick.AddListener(CloseCraftingSystem);

        openButtonTQ.onClick.AddListener(OpenTraderQuestInterface);
        closeButtonTQ.onClick.AddListener(CloseTraderQuestInterface);
    }

    public void CloseInventory()
    {
        uiInventory.transform.position = uiInventory.transform.position - new Vector3(2000, 2000, 0);
        CloseEquipmentSlots();

        openButtonInventory.gameObject.SetActive(true);
        closeButtonInventory.gameObject.SetActive(false);

        inInventory = false;
    }
    public void OpenInventory()
    {
        uiInventory.transform.position = uiInventory.transform.position + new Vector3(2000, 2000, 0);
        OpenEquipmentSlots();

        openButtonInventory.gameObject.SetActive(false);
        closeButtonInventory.gameObject.SetActive(true);

        inInventory = true;
    }

    public void CloseCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingSystem.transform.position - new Vector3(2000, 2000, 0);
        openButtonCrafting.gameObject.SetActive(true);
        closeButtonCrafting.gameObject.SetActive(false);

        inCraftingSystem = false;
    }
    public void OpenCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingSystem.transform.position + new Vector3(2000, 2000, 0);
        openButtonCrafting.gameObject.SetActive(false);
        closeButtonCrafting.gameObject.SetActive(true);

        inCraftingSystem = true;
    }

    public void CloseEquipmentSlots()
    {
        uiEquipmentSlots.transform.position = uiEquipmentSlots.transform.position - new Vector3(2000, 2000, 0);
    }
    public void OpenEquipmentSlots()
    {
        uiEquipmentSlots.transform.position = uiEquipmentSlots.transform.position + new Vector3(2000, 2000, 0);
    }

    public void CloseTraderQuestInterface()
    {
        uiTraderQuest.transform.position = uiTraderQuest.transform.position - new Vector3(2000, 2000, 0);

        openButtonTQ.gameObject.SetActive(true);
        closeButtonTQ.gameObject.SetActive(false);
    }
    public void OpenTraderQuestInterface()
    {
        uiTraderQuest.transform.position = uiTraderQuest.transform.position + new Vector3(2000, 2000, 0);

        openButtonTQ.gameObject.SetActive(false);
        closeButtonTQ.gameObject.SetActive(true);
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
