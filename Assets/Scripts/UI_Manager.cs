using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private GameObject gameManager;

    private GameObject uiInventory;
    private GameObject uiCrafting;
    private GameObject uiEquipment;
    private GameObject uiQuest;
    private GameObject uiStats;

    private Button openButtonInventory;
    private Button closeButtonInventory;
    private Button openButtonCrafting;
    private Button closeButtonCrafting;
    private Button openButtonTQ;
    private Button closeButtonTQ;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Start()
    {
        //Closing inventory and crafting and quest systems after everything is initialized
        if (uiInventory)
            CloseInventory();
        if (uiCrafting)
            CloseCrafting();
        if (uiQuest)
            CloseQuest();
        if (uiStats)
            CloseStats();

        UpdateButtonStatus();
    }

    #region Setters
    public void SetUIInventory(GameObject uiInventory)
    {
        this.uiInventory = uiInventory;
    }
    public void SetUIEquipment(GameObject uiEquipment)
    {
        this.uiEquipment = uiEquipment;
    }
    public void SetUICrafting(GameObject uiCraftingSystem)
    {
        this.uiCrafting = uiCraftingSystem;
    }
    public void SetUIQuest(GameObject uiQuestInterface)
    {
        this.uiQuest = uiQuestInterface;
    }
    public void SetUIStats(GameObject uiStats)
    {
        this.uiStats = uiStats;
    }
    public void SetButton(Button button, bool isOpen, string system)
    {
        if (isOpen)
        {
            switch (system)
            {
                case "Inventory": openButtonInventory = button; openButtonInventory.onClick.AddListener(OpenInventory);
                    break;
                case "Crafting": openButtonCrafting = button; openButtonCrafting.onClick.AddListener(OpenCrafting);
                    break;
                case "Quest": openButtonTQ = button; openButtonTQ.onClick.AddListener(OpenQuest);
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
                    closeButtonCrafting = button; closeButtonCrafting.onClick.AddListener(CloseCrafting);
                    break;
                case "Quest":
                    closeButtonTQ = button; closeButtonTQ.onClick.AddListener(CloseQuest);
                    break;
            }
        }
    }
    #endregion

    #region Actions
    public void OpenInventory()
    {
        OpenInventoryUI();
        OpenEquipmentUI();

        UpdateButtonStatus();

    }
    public void CloseInventory()
    {
        CloseInventoryUI();
        CloseEquipmentUI();
        CloseCraftingUI();

        UpdateButtonStatus();
    }

    public void OpenCrafting()
    {
        OpenCraftingUI();
        OpenInventoryUI();

        UpdateButtonStatus();

    }
    public void CloseCrafting()
    {
        CloseCraftingUI();

        UpdateButtonStatus();


    }

    public void OpenEquipment()
    {
        OpenEquipmentUI();

        UpdateButtonStatus();
    }
    public void CloseEquipment()
    {
        CloseEquipmentUI();

        UpdateButtonStatus();
    }

    public void OpenQuest()
    {
        //OpenQuestUI();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
    }
    public void CloseQuest()
    {
        CloseQuestUI();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
    }
    public void OpenStats()
    {
        OpenStatsUI();
    }

    public void CloseStats()
    {
        CloseStatsUI();
    }
    #endregion

    #region UI
    public void OpenInventoryUI()
    {
        uiInventory.SetActive(true);
    }
    public void CloseInventoryUI()
    {
        uiInventory.SetActive(false);
    }

    public void OpenEquipmentUI()
    {
        uiEquipment.SetActive(true);
    }
    public void CloseEquipmentUI()
    {
        uiEquipment.SetActive(false);
    }

    public void OpenCraftingUI()
    {
        uiCrafting.SetActive(true);
    }
    public void CloseCraftingUI()
    {
        uiCrafting.SetActive(false);
    }

    public void SetQuestUI()
    {

    }
    public void OpenQuestUI(Quest quest, ItemObject itemObject)
    {
        uiQuest.SetActive(true);
        uiQuest.GetComponent<QuestUI>().SetSummary(quest.summary);
        uiQuest.GetComponent<QuestUI>().SetObjective(itemObject, quest.summary);

    }
    public void CloseQuestUI()
    {
        uiQuest.SetActive(false);
    }

    public void OpenStatsUI()
    {
        uiStats.SetActive(true);
    }

    public void CloseStatsUI()
    {
        uiStats.SetActive(false);
    }
    #endregion

    public void UpdateButtonStatus()
    {
        #region Inventory
        if (uiInventory != null && uiInventory.gameObject.activeInHierarchy)
        {
            //Inventory UI is open.
            openButtonInventory.gameObject.SetActive(false);
            closeButtonInventory.gameObject.SetActive(true);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", true);
        }
        else
        {
            //Inventory UI is closed.
            openButtonInventory.gameObject.SetActive(true);
            closeButtonInventory.gameObject.SetActive(false);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", false);
        }
        #endregion

        #region Equipment
        if (uiEquipment != null && uiEquipment.gameObject.activeInHierarchy)
        {
            //Equipment UI is open.
            gameManager.GetComponent<GM_StateManager>().SetStatus("Equipment", true);
        }
        else
        {
            //Equipment UI is closed.
            gameManager.GetComponent<GM_StateManager>().SetStatus("Equipment", false);
        }
        #endregion

        #region Crafting
        if (uiCrafting != null && uiCrafting.gameObject.activeInHierarchy)
        {
            //Crafting UI is open.
            openButtonCrafting.gameObject.SetActive(false);
            closeButtonCrafting.gameObject.SetActive(true);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", true);
        }
        else
        {
            //Crafting UI is closed.
            openButtonCrafting.gameObject.SetActive(true);
            closeButtonCrafting.gameObject.SetActive(false);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", false);
        }
        #endregion

        #region Quest
        //if (uiQuest != null && uiQuest.gameObject.activeInHierarchy)
        //{
        //    //Quest UI is open.
        //    openButtonTQ.gameObject.SetActive(false);
        //    closeButtonTQ.gameObject.SetActive(true);
        //    gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
        //}
        //else
        //{
        //    //Quest UI is closed.
        //    openButtonTQ.gameObject.SetActive(true);
        //    closeButtonTQ.gameObject.SetActive(false);
        //    gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
        //}
        #endregion
    }
}
