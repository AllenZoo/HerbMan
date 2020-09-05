using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Inventory inventory;
    public event EventHandler OnEquipChanged;
    public event EventHandler OnCollisionVein;

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory(UseItem, 20);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        ItemWorldVein itemWorldVein = collider.GetComponent<ItemWorldVein>();

        if(itemWorld != null)
        {
            if (itemWorldVein != null)
            {
                //If is Vein
                return;
            }
            else
            {
                //If is item
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    { 
        ItemWorldVein itemWorldVein = collider.GetComponent<ItemWorldVein>();

        if (itemWorldVein != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                //OnCollisionVein?.Invoke(this, EventArgs.Empty);
                if (itemWorldVein.CanHarvest())
                {
                    inventory.AddItem(itemWorldVein.Harvest());
                }
            }
        }
    }
    private void UseItem(Item item)
    {
        if (item.IsTool())
        {
            Debug.Log("Using Tool!");
            //Equip Tool
            switch (item.itemType)
            {
                default: break;
                case Item.ItemType.StonePickaxe: break;

            }
        }

        if (item.IsMaterial())
        {
            switch (item.itemType)
            {
                default: break;
            }
        }
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
    
    public void SetEquipment(Item item)
    {
        SetEquipment(item.itemType);
    }
    public void SetEquipment(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default: break;
        }
        OnEquipChanged?.Invoke(this, EventArgs.Empty);
    }
}
