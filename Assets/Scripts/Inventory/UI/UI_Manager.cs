using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private GameObject gameManager;

    //[Header("Crafting System")]
    private Transform uiCraftingSystem;
    private Button openButtonCrafting;
    private Button closeButtonCrafting;

    //[Header("Equipment Slots")]
    private Transform uiEquipmentSlots;

    //[Header("Inventory")]
    private Transform uiInventory;
    private Button openButtonInventory;
    private Button closeButtonInventory;

    //[Header("Trader Quests")]
    private Transform uiQuestInterface;
    private Button openButtonTQ;
    private Button closeButtonTQ;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        uiCraftingSystem = FindObjectOfType<UI_CraftingSystem>().transform;
        uiEquipmentSlots = FindObjectOfType<UI_CharacterEquipment>().transform;
        uiInventory = FindObjectOfType<UI_Inventory>().transform;
        uiQuestInterface = FindObjectOfType<UI_TraderQuest>().transform;
    }

    private void Start()
    {
        //Closing inventory and crafting and quest systems after everything is initialized
        Invoke("CloseInventory", 0.1f);
        Invoke("CloseCraftingSystem", 0.1f);
        Invoke("CloseTraderQuestInterface", 0.1f);
    }
    

    public void SetUIInventory(Transform uiInventory)
    {
        //this.uiInventory = uiInventory;
    }
    public void SetUIEquipment(Transform uiEquipment)
    {
       // uiEquipmentSlots = uiEquipment;
    }
    public void SetUICraftingSystem(Transform uiCraftingSystem)
    {
        //this.uiCraftingSystem = uiCraftingSystem;
    }
    public void SetUIQuestInterface(Transform uiQuestInterface)
    {
        //this.uiQuestInterface = uiQuestInterface;
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

        gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", false);
    }
    public void OpenInventory()
    {
        uiInventory.transform.position = uiInventory.transform.position + new Vector3(2000, 2000, 0);
        OpenEquipmentSlots();

        openButtonInventory.gameObject.SetActive(false);
        closeButtonInventory.gameObject.SetActive(true);

        gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", true);
    }

    public void CloseCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingSystem.transform.position - new Vector3(2000, 2000, 0);
        openButtonCrafting.gameObject.SetActive(true);
        closeButtonCrafting.gameObject.SetActive(false);

        gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", false);
    }
    public void OpenCraftingSystem()
    {
        uiCraftingSystem.transform.position = uiCraftingSystem.transform.position + new Vector3(2000, 2000, 0);
        openButtonCrafting.gameObject.SetActive(false);
        closeButtonCrafting.gameObject.SetActive(true);

        gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", true);
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

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
    }
    public void OpenTraderQuestInterface()
    {
        uiQuestInterface.transform.position = uiQuestInterface.transform.position + new Vector3(2000, 2000, 0);

        openButtonTQ.gameObject.SetActive(false);
        closeButtonTQ.gameObject.SetActive(true);

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
    }

}
