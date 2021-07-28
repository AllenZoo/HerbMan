using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public abstract class UserInterface : MonoBehaviour
{
    public InventoryObject inventory;
    public Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

    private void Start()
    {
        for(int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].parent = this;
            inventory.GetSlots[i].OnAfterUpdate += OnSlotUpdate;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    private void OnSlotUpdate(InventorySlot _slot)
    {
        if (_slot.item != null && _slot.item.id >= 0)
        {
            //update slot with item
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.ItemObject.sprite;
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            _slot.slotDisplay.GetComponentInChildren<Text>().text = _slot.amount == 1 ? "" : _slot.amount.ToString("n0");

            _slot.slotDisplay.transform.Find("emptyImage (icon)")?.transform.gameObject.SetActive(false);
        }
        else
        {
            //clear slot
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            _slot.slotDisplay.GetComponentInChildren<Text>().text = "";

            _slot.slotDisplay.transform.Find("emptyImage (icon)")?.transform.gameObject.SetActive(true);
        }
    }

    //private void Update()
    //{
    //    slotsOnInterface.UpdateSlotDisplay();
    //}

    public abstract void CreateSlots();
    public abstract InventorySlot InstantiateNewSlot();


    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
    }

    public void OnExit(GameObject obj)
    {
        MouseData.slotHoveredOver = null;
    }

    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();
    }

    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
    }

    public void OnDragStart(GameObject obj)
    {
        MouseData.tempItemBeingDragged = CreateTempItem(obj);
    }

    public GameObject CreateTempItem(GameObject obj)
    {
        GameObject tempItem = null;

        if(slotsOnInterface[obj].item.id >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(60, 60);
            tempItem.transform.SetParent(transform.parent.parent);
            var image = tempItem.AddComponent<Image>();
            image.sprite = slotsOnInterface[obj].ItemObject.sprite;
            image.raycastTarget = false;
        }
        return tempItem;
    }

    public void OnDragEnd(GameObject obj)
    {
        //obj = object which is dragged
        Destroy(MouseData.tempItemBeingDragged);

        if (slotsOnInterface[obj].item.id <= -1)
        {
            return;
        }

        if (MouseData.interfaceMouseIsOver == null)
        {
            //TODO : IMPLEMENT DROP ITEM 
            slotsOnInterface[obj].RemoveItem();
            return;
        }

        if (MouseData.additiveSlotHoveredOver)
        {
            //CREATE INVENTORY SLOT
            InventorySlot emptySlot = new InventorySlot();

            //Debug.Log("Additive Slot dragged to");

            UserInterface ui = MouseData.additiveSlotHoveredOver.GetComponent<AdditiveSlot>().ui;
            InventoryObject invObject = MouseData.additiveSlotHoveredOver.GetComponent<AdditiveSlot>().ui.inventory;

            //Debug.Log("Before : " + invObject.GetSlots.Length);

            //Find Empty Slot
            if(invObject.EmptySlotCount <= 0) {
                invObject.container.SetSlots(invObject.container.slots.Length + 1);
                emptySlot = ui.InstantiateNewSlot();
                emptySlot = invObject.GetSlots[invObject.container.slots.Length - 1];
            }
            else
            {
                for (int i = 0; i < invObject.GetSlots.Length; i++)
                {
                    if (invObject.GetSlots[i].item.id <= -1)
                    {
                        emptySlot = invObject.GetSlots[i];
                        break;
                    }
                }
            }
            
            //Debug.Log("After : " + invObject.GetSlots.Length);


            //SWAP ITEMS BETWEEN SLOTS 
            
            

            //InventorySlot addSlot = ui.slotsOnInterface[firstEmptySlot];
            inventory.SwapItems(emptySlot, slotsOnInterface[obj]);

            emptySlot.OnAfterUpdate.Invoke(emptySlot);
            //Debug.Log(emptySlot.item.id);
            //OnSlotUpdate(emptySlot);
        }

        else if(MouseData.slotHoveredOver)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            inventory.SwapItems(slotsOnInterface[obj], mouseHoverSlotData);
        }
         

    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemBeingDragged != null)
        {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
}

public static class MouseData
{
    public static UserInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoveredOver;
    public static GameObject additiveSlotHoveredOver;
}


