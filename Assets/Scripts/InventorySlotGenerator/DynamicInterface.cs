using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class DynamicInterface : UserInterface
{
    public GameObject inventorySlotPrefab;

    public Transform slotParent;

    public bool isInteractable = true;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS = 1;
    public int Y_SPACE_BETWEEN_ITEMS;
    private int slots;

    public override void CreateSlots()
    {
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

        if (slotParent == null)
        {
            slotParent = transform;
        }

        slots = inventory.GetSlots.Length;
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            var obj = Instantiate(inventorySlotPrefab, Vector3.zero, Quaternion.identity, slotParent);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            if (isInteractable)
            {
                AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
                AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
                AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
                AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
                AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            }

            inventory.GetSlots[i].slotDisplay = obj;

            slotsOnInterface.Add(obj, inventory.GetSlots[i]);
        }

    }

    public override InventorySlot InstantiateNewSlot()
    {
        slots = inventory.GetSlots.Length;
        var obj = Instantiate(inventorySlotPrefab, Vector3.zero, Quaternion.identity, slotParent);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(slots);

        inventory.GetSlots[slots - 1] = new InventorySlot();
        inventory.GetSlots[slots - 1].slotDisplay = obj;
        slotsOnInterface.Add(obj, inventory.GetSlots[1]);

        return inventory.GetSlots[slots - 1];
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMNS)), 0);
    }
}
