using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_CharacterEquipmentSlot : MonoBehaviour, IDropHandler
{

    public event EventHandler<OnItmDroppedEventArgs> OnItemDropped;
    public class OnItmDroppedEventArgs : EventArgs
    {
        public Item item;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Item item = ItemDragUI.Instance.GetItem();
        OnItemDropped?.Invoke(this, new OnItmDroppedEventArgs { item = item });
    }
}
