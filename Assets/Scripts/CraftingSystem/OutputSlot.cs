using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputSlot : MonoBehaviour
{
    public static OutputSlot Instance { get; private set; }

    private CraftingSystem craftingSystem;
    private Transform outputSlotImage;
    private Item output;

    private void Awake()
    {
        outputSlotImage = transform.Find("outputItemSlot");
        craftingSystem.OnItemCrafted += CraftingSystem_OnItemCrafted;
    }

    private void CraftingSystem_OnItemCrafted(object sender, EventArgs e)
    {
        ShowItem();
        Debug.Log("Output Slot Showing: " + output.ToString());
    }

    public Item GetOutput()
    {
        return output;
    }
    public void SetOutputItem(Item output)
    {
        this.output = output;

    }
    public void ShowItem()
    {
        outputSlotImage.gameObject.SetActive(true);
    }
}
