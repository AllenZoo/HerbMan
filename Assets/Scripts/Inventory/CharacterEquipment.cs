using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public event EventHandler OnEquipmentChanged;

    public enum EquipSlot
    {
        UnEquipable,
        Pickaxe,
        Axe,
        Sickle,
    }
    private Player player;

    private Item pickaxeItem;
    private Item axeItem;
    private Item sickleItem;

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

    private void SetPickaxeItem(Item pickaxeItem)
    {
        this.pickaxeItem = pickaxeItem;
        player.SetEquipment(pickaxeItem);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetAxeItem(Item axeItem)
    {
        this.axeItem = axeItem;
        player.SetEquipment(axeItem);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    private void SetSickleItem(Item sickleItem)
    {
        this.sickleItem = sickleItem;
        player.SetEquipment(sickleItem);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }

    public void TryEquipItem(EquipSlot equipSlot, Item item)
    {
        if(equipSlot == item.GetEquipSlot())
        {
            //Item matches equipment slot
            switch (equipSlot)
            {
                default:
                case EquipSlot.Pickaxe: SetPickaxeItem(item); break;
                case EquipSlot.Axe: SetAxeItem(item); break;
                case EquipSlot.Sickle: SetSickleItem(item); break;
            }
        }
    }
    public bool IsSuitableSlot(EquipSlot equipSlot, Item item)
    {
        return equipSlot == item.GetEquipSlot();
    }
}
