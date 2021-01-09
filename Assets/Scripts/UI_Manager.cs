using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] InventoryObject rewardInventory;

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
        {
            Invoke("CloseInventory", 1/100);
        }

        if (uiCrafting)
        {
            Invoke("CloseCrafting", 1 / 100);
        }

        if (uiQuest)
        {
            Invoke("CloseQuest", 1 / 100);
        }

        if (uiStats)
        {
            Invoke("CloseStats", 1 / 100);
        }

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

    #region Inventory
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
    #endregion

    #region Crafting
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
    #endregion

    #region Equipment
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
    #endregion

    #region Quest
    public void OpenQuest()
    {
        OpenQuestUI();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
    }
    public void CloseQuest()
    {
        CloseQuestUI();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
    }
    #endregion

    #region Stats
    public void OpenStats()
    {
        OpenStatsUI();
    }
    public void CloseStats()
    {
        CloseStatsUI();
    }
    #endregion

    #endregion

    #region UI

    #region Inventory
    public void OpenInventoryUI()
    {
        uiInventory.SetActive(true);
    }
    public void CloseInventoryUI()
    {
        uiInventory.SetActive(false);
    }
    #endregion

    #region Equipment
    public void OpenEquipmentUI()
    {
        uiEquipment.SetActive(true);
    }
    public void CloseEquipmentUI()
    {
        uiEquipment.SetActive(false);
    }
    #endregion

    #region Crafting
    public void OpenCraftingUI()
    {
        uiCrafting.SetActive(true);
    }
    public void CloseCraftingUI()
    {
        uiCrafting.SetActive(false);
    }
    #endregion

    #region Quest
    public GameObject GetQuestUI()
    {
        return uiQuest;
    }

    public void OpenQuestUI()
    {
        uiQuest.SetActive(true);
    }
    public void CloseQuestUI()
    {
        uiQuest.SetActive(false);
    }
    #endregion

    #region Stats
    public void OpenStatsUI()
    {
        uiStats.SetActive(true);
    }

    public void CloseStatsUI()
    {
        uiStats.SetActive(false);
    }
    #endregion

    #endregion

    public void UpdateButtonStatus()
    {
        #region Inventory
        if (uiInventory != null && uiInventory.gameObject.activeInHierarchy)
        {
            //Inventory UI is open.
            openButtonInventory?.gameObject.SetActive(false);
            closeButtonInventory?.gameObject.SetActive(true);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", true);
        }
        else
        {
            //Inventory UI is closed.
            openButtonInventory?.gameObject.SetActive(true);
            closeButtonInventory?.gameObject.SetActive(false);
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
            openButtonCrafting?.gameObject.SetActive(false);
            closeButtonCrafting?.gameObject.SetActive(true);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", true);
        }
        else
        {
            //Crafting UI is closed.
            openButtonCrafting?.gameObject.SetActive(true);
            closeButtonCrafting?.gameObject.SetActive(false);
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

    private void OnApplicationQuit()
    {
        rewardInventory.Clear();
    }
}
