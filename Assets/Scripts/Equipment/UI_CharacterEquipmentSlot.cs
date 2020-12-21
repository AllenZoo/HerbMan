using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_CharacterEquipmentSlot : MonoBehaviour, IDropHandler
{

    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    public class OnItemDroppedEventArgs : EventArgs
    {
        public ItemOld item;
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemOld item = UI_ItemDrag.Instance.GetItem();
        //Debug.Log("Dropped: " + item.ToString());
        if (item.system == ItemOld.SystemType.inventory)
        {
            OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item });
        }
    }
}
