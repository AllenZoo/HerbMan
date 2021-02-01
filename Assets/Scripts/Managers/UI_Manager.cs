using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] InventoryObject rewardInventory;

    public Player player;
    private GameObject gameManager;

    private GameObject uiInventoryGameObject;
    private GameObject uiCraftingGameObject;
    private GameObject uiEquipmentGameObject;
    private GameObject uiQuestGameObject;
    private GameObject uiStatsGameObject;

    private Button openButtonInventory;
    private Button closeButtonInventory;
    private Button openButtonCrafting;
    private Button closeButtonCrafting;
    private Button openButtonQG;
    private Button closeButtonQG;

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

        if (uiInventoryGameObject)
        {
            Invoke("CloseInventoryWindow", 1/100);
        }

        if (uiCraftingGameObject)
        {
            Invoke("CloseCraftingWindow", 1 / 100);
        }

        if (uiQuestGameObject)
        {
            Invoke("CloseQuestWindow", 1 / 100);
        }

        if (uiStatsGameObject)
        {
            Invoke("CloseStatsWindow", 1 / 100);
        }

        UpdateButtonStatus();
    }

    #region Setters
    public void SetUIInventory(GameObject uiInventory)
    {
        this.uiInventoryGameObject = uiInventory;
    }
    public void SetUIEquipment(GameObject uiEquipment)
    {
        this.uiEquipmentGameObject = uiEquipment;
    }
    public void SetUICrafting(GameObject uiCraftingSystem)
    {
        this.uiCraftingGameObject = uiCraftingSystem;
    }
    public void SetUIQuest(GameObject uiQuestInterface)
    {
        this.uiQuestGameObject = uiQuestInterface;
    }
    public void SetUIStats(GameObject uiStats)
    {
        this.uiStatsGameObject = uiStats;
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
            }
        }
    }
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

    #endregion

    #region UI

    #region Inventory
    public void OpenInventoryUI()
    {
        uiInventoryGameObject.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseInventoryUI()
    {
        uiInventoryGameObject.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

    #region Equipment
    public void OpenEquipmentUI()
    {
        uiEquipmentGameObject.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseEquipmentUI()
    {
        uiEquipmentGameObject.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

    #region Crafting
    public void OpenCraftingUI()
    {
        uiCraftingGameObject.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseCraftingUI()
    {
        uiCraftingGameObject.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

    #region Quest
    public GameObject GetQuestUI()
    {
        return uiQuestGameObject;
    }

    public void OpenQuestUI()
    {
        uiQuestGameObject.SetActive(true);
        UpdateButtonStatus();
    }
    public void CloseQuestUI()
    {
        uiQuestGameObject.SetActive(false);
        UpdateButtonStatus();
    }
    #endregion

    #region Stats
    public void OpenStatsUI()
    {
        uiStatsGameObject.SetActive(true);
    }

    public void CloseStatsUI()
    {
        uiStatsGameObject.SetActive(false);
    }
    #endregion

    #endregion

    public void UpdateButtonStatus()
    {
        #region Inventory
        if (uiInventoryGameObject != null && uiInventoryGameObject.gameObject.activeInHierarchy)
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
        if (uiEquipmentGameObject != null && uiEquipmentGameObject.gameObject.activeInHierarchy)
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
        if (uiCraftingGameObject != null && uiCraftingGameObject.gameObject.activeInHierarchy)
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
        if (uiQuestGameObject != null && uiQuestGameObject.gameObject.activeInHierarchy)
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
    }

    private void OnApplicationQuit()
    {
        rewardInventory.Clear();
    }
}
