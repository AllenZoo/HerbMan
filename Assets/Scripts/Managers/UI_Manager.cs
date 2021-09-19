using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] InventoryObject rewardInventory;

    public Player player;
    private GameObject gameManager;

    private GameObject ui_InventoryGameObject;
    private GameObject ui_CraftingGameObject;
    private GameObject ui_EquipmentGameObject;
    private GameObject ui_QuestGameObject;
    private GameObject ui_StatsGameObject;
    private GameObject ui_shopGameObject;

    private Button openButtonInventory;
    private Button closeButtonInventory;
    private Button openButtonCrafting;
    private Button closeButtonCrafting;
    private Button openButtonQG;
    private Button closeButtonQG;
    private Button openShopButton;
    private Button closeShopButton;

    private Quest curQuest;
    private Sprite questPortrait;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        //Closing inventory and crafting and quest systems after everything is initialized

        if (ui_InventoryGameObject)
        {
            Invoke("CloseInventoryWindow", 1/100);
        }

        if (ui_CraftingGameObject)
        {
            Invoke("CloseCraftingWindow", 1 / 100);
        }

        if (ui_QuestGameObject)
        {
            Invoke("CloseQuestWindow", 1 / 100);
        }

        if (ui_StatsGameObject)
        {
            Invoke("CloseStatsWindow", 1 / 100);
        }

        if (ui_shopGameObject)
        {
            Invoke("CloseShopWindow", 1 / 100);
        }

        //Invoke("UpdateButtonStatus", 2);
        
        UpdateButtonStatus();
    }

    #region Setters
    public void SetUIInventory(GameObject uiInventory)
    {
        this.ui_InventoryGameObject = uiInventory;
    }
    public void SetUIEquipment(GameObject uiEquipment)
    {
        this.ui_EquipmentGameObject = uiEquipment;
    }
    public void SetUICrafting(GameObject uiCraftingSystem)
    {
        this.ui_CraftingGameObject = uiCraftingSystem;
    }
    public void SetUIQuest(GameObject uiQuestInterface)
    {
        this.ui_QuestGameObject = uiQuestInterface;
    }
    public void SetUIStats(GameObject uiStats)
    {
        this.ui_StatsGameObject = uiStats;
    }
    public void SetUIShop(GameObject uiShop)
    {
        this.ui_shopGameObject = uiShop;
    }
    public void SetButton(Button button, bool isOpen, string system)
    {
        if (isOpen)
        {
            switch (system)
            {
                case "Inventory": openButtonInventory = button; openButtonInventory.onClick.AddListener(OpenInventoryWindow);
                    break;
                case "Crafting": openButtonCrafting = button; openButtonCrafting.onClick.AddListener(OpenCraftingWindow);
                    break;
                case "Quest": openButtonQG = button; openButtonQG.onClick.AddListener(OpenQuestWindow);
                    break;
                case "Shop": openShopButton = button; openShopButton.onClick.AddListener(OpenShopWindow);
                    break;
            }
        }
        else
        {
            switch (system)
            {
                case "Inventory":
                    closeButtonInventory = button; closeButtonInventory.onClick.AddListener(CloseInventoryWindow);
                    break;
                case "Crafting":
                    closeButtonCrafting = button; closeButtonCrafting.onClick.AddListener(CloseCraftingWindow);
                    break;
                case "Quest":
                    closeButtonQG = button; closeButtonQG.onClick.AddListener(CloseQuestWindow);
                    break;
                case "Shop":
                    closeShopButton = button; closeShopButton.onClick.AddListener(CloseShopWindow);
                    break;
            }
        }
    }
    #endregion

    #region UI

        #region Inventory
    public void OpenInventoryUI()
    {
        ui_InventoryGameObject.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseInventoryUI()
    {
        ui_InventoryGameObject.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

        #region Equipment
    public void OpenEquipmentUI()
    {
        ui_EquipmentGameObject?.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseEquipmentUI()
    {
        ui_EquipmentGameObject?.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

        #region Crafting
    public void OpenCraftingUI()
    {
        ui_CraftingGameObject?.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseCraftingUI()
    {
        ui_CraftingGameObject?.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

        #region Quest
    public GameObject GetQuestUI()
    {
        return ui_QuestGameObject;
    }

    public void OpenQuestUI()
    {
        ui_QuestGameObject?.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseQuestUI()
    {
        ui_QuestGameObject?.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

        #region Shop
    public void OpenShopUI()
    {
        ui_shopGameObject.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseShopUI()
    {
        ui_shopGameObject.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

        #region Stats
    public void OpenStatsUI()
    {
        ui_StatsGameObject?.SetActive(true);
    }

    public void CloseStatsUI()
    {
        ui_StatsGameObject?.SetActive(false);
    }
    #endregion

    #endregion

    #region Actions

        #region Inventory
    public void OpenInventoryWindow()
    {
        OpenInventoryUI();
        OpenEquipmentUI();
        OpenStatsUI();
    }
    public void CloseInventoryWindow()
    {
        CloseInventoryUI();
        CloseEquipmentUI();
        CloseCraftingUI();
        CloseStatsUI();
    }
        #endregion

        #region Crafting
    public void OpenCraftingWindow()
    {
        OpenCraftingUI();
        OpenInventoryUI();
    }
    public void CloseCraftingWindow()
    {
        CloseCraftingUI();
    }
        #endregion

        #region Equipment
    public void OpenEquipmentWindow()
    {
        OpenEquipmentUI();
    }
    public void CloseEquipmentWindow()
    {
        CloseEquipmentUI();
    }
        #endregion

        #region Quest
    public void OpenQuestWindow()
    {
        OpenQuestUI();

        FindObjectOfType<UI_QuestManager>().UpdateQuestUI();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
    }


    public void CloseQuestWindow()
    {
        CloseQuestUI();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
    }
        #endregion

        #region Stats
    public void OpenStatsWindow()
    {
        OpenStatsUI();
    }
    public void CloseStatsWindow()
    {
        CloseStatsUI();
    }
        #endregion

        #region Shop
    public void OpenShopWindow()
    {
        OpenShopUI();
    }
    public void CloseShopWindow()
    {
        CloseShopUI();
    }
        #endregion

    #endregion

    public void UpdateButtonStatus()
    {
        #region Inventory
        if (ui_InventoryGameObject != null && ui_InventoryGameObject.gameObject.activeInHierarchy)
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
        if (ui_EquipmentGameObject != null && ui_EquipmentGameObject.gameObject.activeInHierarchy)
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
        if (ui_CraftingGameObject != null && ui_CraftingGameObject.gameObject.activeInHierarchy)
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
        if (ui_QuestGameObject != null && ui_QuestGameObject.gameObject.activeInHierarchy)
        {
            //Quest UI is open.
            openButtonQG?.gameObject.SetActive(false);
            closeButtonQG?.gameObject.SetActive(true);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
        }
        else
        {
            //Quest UI is closed.
            openButtonQG?.gameObject.SetActive(true);
            closeButtonQG?.gameObject.SetActive(false);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
        }
        #endregion

        #region Shop
        if(ui_shopGameObject != null && ui_shopGameObject.gameObject.activeInHierarchy)
        {
            //Shop UI is open
            openShopButton?.gameObject.SetActive(false);
            closeShopButton?.gameObject.SetActive(true);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Shop", true);
        }
        else
        {
            //Shop UI is closed
            openShopButton?.gameObject.SetActive(true);
            closeShopButton?.gameObject.SetActive(false);
            gameManager.GetComponent<GM_StateManager>().SetStatus("Shop", false);
        }

        #endregion
    }

    private void OnApplicationQuit()
    {
        //rewardInventory.Clear();
    }
}
