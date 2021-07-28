using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Shop))]
public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject itemSlotTemplate;
    [SerializeField] InventoryObject sellInventory;
    private Shop shopRef;

    //Where the lists should be displayed
    private Transform buyAreaDisplay;
    private Transform displayAreaDisplay;

    private Transform sellAreaDisplay;

    private void Awake()
    {
        shopRef = GetComponent<Shop>();

        buyAreaDisplay = this.transform.Find("UI").Find("buySection(right)");
        sellAreaDisplay = this.transform.Find("UI").Find("sellSection(left)").Find("ButtonScrollList").Find("ButtonListViewport").Find("ButtonListContent");
    }

    private void Start()
    {
        ClearInventory();
        shopRef.OnListChanged += RefreshDisplay;
    }

    private void DisplayItems()
    {
        List<ItemObject> sellItemObjectList = shopRef.GetSellListItems();

        foreach (Transform child in sellAreaDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < sellItemObjectList.Count; i++)
        {
            GameObject gameObject = Instantiate(itemSlotTemplate, sellAreaDisplay);
            gameObject.transform.Find("image").GetComponent<Image>().sprite = sellItemObjectList[i].sprite;



        }
    }

    private void RefreshDisplay(object sender, EventArgs e)
    {
        //Debug.Log("List Changed, " + sender.ToString() + e.ToString());
        DisplayItems();
    }

    private void ClearInventory()
    {
        sellInventory.container.SetSlots(2);

        sellInventory.Load();
    }

}
