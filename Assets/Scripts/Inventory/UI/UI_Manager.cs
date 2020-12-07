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
    private Transform uiQuestInterface;
    private Button openButtonTQ;
    private Button closeButtonTQ;

    private bool inCraftingSystem;
    private bool inInventory;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inCraftingSystem = true;
        inInventory = true;

        //Closing inventory and crafting and quest systems after everything is initialized
        Invoke("CloseInventory", 0.1f);
        Invoke("CloseCraftingSystem", 0.1f);
        Invoke("CloseTraderQuestInterface", 0.1f);

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

    public void SetUIInventory(Transform uiInventory)
    {
        this.uiInventory = uiInventory;
    }
    public void SetUIEquipment(Transform uiEquipment)
    {
        uiEquipmentSlots = uiEquipment;
    }
    public void SetUICraftingSystem(Transform uiCraftingSystem)
    {
        this.uiCraftingSystem = uiCraftingSystem;
    }
    public void SetUIQuestInterface(Transform uiQuestInterface)
    {
        this.uiQuestInterface = uiQuestInterface;
    }
    public void SetButton(Button button, bool isOpen, string system)
    {
        if (isOpen)
        {
            switch (system)
            {
                case "Inventory": openButtonInventory = button; openButtonInventory.onClick.AddListener(OpenInventory);
                    break;
                case "Crafting": openButtonCrafting = button; openButtonCrafting.onClick.AddListener(OpenCraftingSystem);
                    break;
                case "Quest": openButtonTQ = button; openButtonTQ.onClick.AddListener(OpenTraderQuestInterface);
                    break;
            }
        }
        else
        {
            switch (system)
            {
                case "Inventory":
                    closeButtonInventory = button; closeButtonInventory.onClick.AddListener(CloseInventory);
                    break;
                case "Crafting":
                    closeButtonCrafting = button; closeButtonCrafting.onClick.AddListener(CloseCraftingSystem);
                    break;
                case "Quest":
                    closeButtonTQ = button; closeButtonTQ.onClick.AddListener(CloseTraderQuestInterface);
                    break;
            }
        }
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
        uiQuestInterface.transform.position = uiQuestInterface.transform.position - new Vector3(2000, 2000, 0);

        openButtonTQ.gameObject.SetActive(true);
        closeButtonTQ.gameObject.SetActive(false);
    }
    public void OpenTraderQuestInterface()
    {
        uiQuestInterface.transform.position = uiQuestInterface.transform.position + new Vector3(2000, 2000, 0);

        openButtonTQ.gameObject.SetActive(false);
        closeButtonTQ.gameObject.SetActive(true);
    }
    public bool PlayerCanMove()
    {
        return !inCraftingSystem && !inInventory;
    }

}
