using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private GameObject gameManager;

    //[Header("Crafting System")]
    private Transform uiCrafting;
    private Button openButtonCrafting;
    private Button closeButtonCrafting;

    //[Header("Equipment Slots")]
    private Transform uiEquipment;

    //[Header("Inventory")]
    private Transform uiInventory;
    private Button openButtonInventory;
    private Button closeButtonInventory;

    //[Header("Trader Quests")]
    private Transform uiQuest;
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
            Invoke("CloseInventory", 0);
        if(uiCrafting)
            Invoke("CloseCraftingSystem", 0.1f);
        if(uiQuest)
            Invoke("CloseTraderQuestInterface", 0.1f);
    }

    #region Setters
    public void SetUIInventory(Transform uiInventory)
    {
        this.uiInventory = uiInventory;
    }
    public void SetUIEquipment(Transform uiEquipment)
    {
        this.uiEquipment = uiEquipment;
    }
    public void SetUICrafting(Transform uiCraftingSystem)
    {
        this.uiCrafting = uiCraftingSystem;
    }
    public void SetUIQuest(Transform uiQuestInterface)
    {
        this.uiQuest = uiQuestInterface;
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

    public void OpenInventory()
    {
        OpenInventoryUI();
        OpenEquipment();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", true);
    }
    public void CloseInventory()
    {
        CloseInventoryUI();
        CloseEquipment();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Inventory", false);
    }

    public void OpenCrafting()
    {
        uiCrafting.transform.position = uiCrafting.transform.position + new Vector3(2000, 2000, 0);


        gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", true);
    }
    public void CloseCrafting()
    {
        uiCrafting.transform.position = uiCrafting.transform.position - new Vector3(2000, 2000, 0);


        gameManager.GetComponent<GM_StateManager>().SetStatus("Crafting", false);
    }

    public void OpenEquipment()
    {
        OpenEquipmentUI();
    }
    public void CloseEquipment()
    {
        CloseEquipmentUI();
    }

    public void OpenQuest()
    {
        OpenQuestUI();

        UpdateButtonStatus();

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", true);
    }
    public void CloseQuest()
    {
        uiQuest.transform.position = uiQuest.transform.position - new Vector3(2000, 2000, 0);

        openButtonTQ.gameObject.SetActive(true);
        closeButtonTQ.gameObject.SetActive(false);

        gameManager.GetComponent<GM_StateManager>().SetStatus("Quest", false);
    }


    #region UI
    public void OpenInventoryUI()
    {
        uiInventory.gameObject.SetActive(true);
    }
    public void CloseInventoryUI()
    {
        uiInventory.gameObject.SetActive(false);
    }

    public void OpenEquipmentUI()
    {
        uiEquipment.gameObject.SetActive(true);
    }
    public void CloseEquipmentUI()
    {
        uiEquipment.gameObject.SetActive(false);
    }

    public void OpenCraftingUI()
    {
        uiCrafting.gameObject.SetActive(true);
    }
    public void CloseCraftingUI()
    {
        uiCrafting.gameObject.SetActive(false);
    }

    public void OpenQuestUI()
    {
        uiQuest.gameObject.SetActive(true);
    }
    public void CloseQuestUI()
    {
        uiQuest.gameObject.SetActive(false);
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
        }
        else
        {
            //Inventory UI is closed.
            openButtonInventory.gameObject.SetActive(true);
            closeButtonInventory.gameObject.SetActive(false);
        }
        #endregion

        #region Crafting
        if (uiCrafting != null && uiCrafting.gameObject.activeInHierarchy)
        {
            //Crafting UI is open.
            openButtonCrafting.gameObject.SetActive(false);
            closeButtonCrafting.gameObject.SetActive(true);
        }
        //else
        //{
        //    //Crafting UI is closed.
        //    openButtonCrafting.gameObject.SetActive(true);
        //    closeButtonCrafting.gameObject.SetActive(false);
        //}
        #endregion

        #region Quest
        if (uiQuest != null && uiQuest.gameObject.activeInHierarchy)
        {
            //Quest UI is open.
            openButtonTQ.gameObject.SetActive(false);
            closeButtonTQ.gameObject.SetActive(true);
        }
        //else
        //{
        //    //Quest UI is closed.
        //    openButtonTQ.gameObject.SetActive(true);
        //    closeButtonTQ.gameObject.SetActive(false);

        //}
        #endregion
    }
}
