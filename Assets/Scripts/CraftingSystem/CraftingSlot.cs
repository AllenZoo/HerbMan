using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IDropHandler
{

    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    public class OnItemDroppedEventArgs : EventArgs
    {
        public Item item;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Item item = ItemDragUI.Instance.GetItem();
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item });
    }
}
