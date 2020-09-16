using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_OutputSlot : MonoBehaviour
{
    public EventHandler<OnItemCraftedEventArgs> OnItemCrafted;

    public class OnItemCraftedEventArgs : EventArgs
    {
        public Item item;
    }

}
