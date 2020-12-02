using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public event EventHandler OnEquipChanged;

    private Inventory inventory;
    private Player_Base player_Base;
    private Player_ColliderEngine colliderEngine;

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory(UseItem, 20);
        player_Base = GetComponent<Player_Base>();
        colliderEngine = GetComponent<Player_ColliderEngine>();
        colliderEngine.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        colliderEngine.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        colliderEngine.enabled = false;
    }

    public void TakeDamage(float num)
    {
        player_Base.SubtractHealth(num);
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
        //SetEquipment(item.itemType);
    }
    public void SetEquipment(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default: break;
        }
        OnEquipChanged?.Invoke(this, EventArgs.Empty);
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
                case Item.ItemType.Stone_Pickaxe: break;

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
   
}
