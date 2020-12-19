using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Equipment : MonoBehaviour
{
    [SerializeField] internal Player player;
    public event EventHandler OnEquipmentChanged;

    public enum EquipSlot
    {
        UnEquipable,

        //Tools
        Pickaxe,
        Axe,
        Sickle,
        
        //Armor
        Helmet,
        Chestplate,
        Pants,
        Boots,

    }


    private Item pickaxeItem;
    private Item axeItem;
    private Item sickleItem;

    private Item helmetItem;
    private Item chestplateItem;
    private Item pantItem;
    private Item bootItem;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public Item GetPickaxeItem()
    {
        return pickaxeItem;
    }
    public Item GetAxeItem()
    {
        return axeItem;
    }
    public Item GetSickleItem()
    {
        return sickleItem;
    }
    public Item GetHelmetItem()
    {
        return helmetItem;
    }
    public Item GetChestplateItem()
    {
        return chestplateItem;
    }
    public Item GetPantItem()
    {
        return pantItem;
    }
    public Item GetBootItem()
    {
        return bootItem;
    }
   
    public Item GetSlotItem(EquipSlot equipSlot)
    {
        switch (equipSlot)
        {
            case EquipSlot.UnEquipable:
                return null;
            case EquipSlot.Pickaxe:
                return GetPickaxeItem();
            case EquipSlot.Axe:
                return GetAxeItem();
            case EquipSlot.Sickle:
                return GetSickleItem();
            case EquipSlot.Helmet:
                return GetHelmetItem();
            case EquipSlot.Chestplate:
                return GetChestplateItem();
            case EquipSlot.Pants:
                return GetPantItem();
            case EquipSlot.Boots:
                return GetBootItem();
        }

        return null;
    }
    public void SetSlotItem(EquipSlot equipSlot, Item item)
    {
        //failproof to check if item and slot are suitable
        if (item == null || equipSlot == item.GetEquipSlot())
        {
            switch (equipSlot)
            {
                case EquipSlot.Pickaxe: SetPickaxeItem(item); break;
                case EquipSlot.Axe: SetAxeItem(item); break;
                case EquipSlot.Sickle: SetSickleItem(item); break;
                case EquipSlot.Helmet: SetHelmetItem(item); break;
                case EquipSlot.Chestplate: SetChestplateItem(item); break;
                case EquipSlot.Pants: SetPantItem(item); break;
                case EquipSlot.Boots: SetBootItem(item); break;
            }
        }
    }
    public bool IsSuitableSlot(EquipSlot equipSlot, Item item)
    {
        return equipSlot == item.GetEquipSlot();
    }
    private void SetPickaxeItem(Item pickaxeItem)
    {
        this.pickaxeItem = pickaxeItem;
        //player.SetEquipment(pickaxeItem);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetAxeItem(Item axeItem)
    {
        this.axeItem = axeItem;
        //player.SetEquipment(axeItem);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetSickleItem(Item sickleItem)
    {
        this.sickleItem = sickleItem;
        //player.SetEquipment(sickleItem);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetHelmetItem(Item helmetItem)
    {
        this.helmetItem = helmetItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetChestplateItem(Item chestplateItem)
    {
        this.chestplateItem = chestplateItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetPantItem(Item pantItem)
    {
        this.pantItem = pantItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetBootItem(Item bootItem)
    {
        this.bootItem = bootItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }

}
