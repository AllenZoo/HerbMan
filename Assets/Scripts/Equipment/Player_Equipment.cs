using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Equipment : MonoBehaviour
{
    //[SerializeField] internal Player player;
    //public event EventHandler OnEquipmentChanged;

    //public enum EquipSlot
    //{
    //    UnEquipable,

    //    //Tools
    //    Pickaxe,
    //    Axe,
    //    Sickle,
        
    //    //Armor
    //    Helmet,
    //    Chestplate,
    //    Pants,
    //    Boots,

    //}


    //private ItemOld pickaxeItem;
    //private ItemOld axeItem;
    //private ItemOld sickleItem;

    //private ItemOld helmetItem;
    //private ItemOld chestplateItem;
    //private ItemOld pantItem;
    //private ItemOld bootItem;

    //private void Awake()
    //{
    //    player = GetComponent<Player>();
    //}

    //public ItemOld GetPickaxeItem()
    //{
    //    return pickaxeItem;
    //}
    //public ItemOld GetAxeItem()
    //{
    //    return axeItem;
    //}
    //public ItemOld GetSickleItem()
    //{
    //    return sickleItem;
    //}
    //public ItemOld GetHelmetItem()
    //{
    //    return helmetItem;
    //}
    //public ItemOld GetChestplateItem()
    //{
    //    return chestplateItem;
    //}
    //public ItemOld GetPantItem()
    //{
    //    return pantItem;
    //}
    //public ItemOld GetBootItem()
    //{
    //    return bootItem;
    //}
   
    //public ItemOld GetSlotItem(EquipSlot equipSlot)
    //{
    //    switch (equipSlot)
    //    {
    //        case EquipSlot.UnEquipable:
    //            return null;
    //        case EquipSlot.Pickaxe:
    //            return GetPickaxeItem();
    //        case EquipSlot.Axe:
    //            return GetAxeItem();
    //        case EquipSlot.Sickle:
    //            return GetSickleItem();
    //        case EquipSlot.Helmet:
    //            return GetHelmetItem();
    //        case EquipSlot.Chestplate:
    //            return GetChestplateItem();
    //        case EquipSlot.Pants:
    //            return GetPantItem();
    //        case EquipSlot.Boots:
    //            return GetBootItem();
    //    }

    //    return null;
    //}
    //public void SetSlotItem(EquipSlot equipSlot, ItemOld item)
    //{
    //    //failproof to check if item and slot are suitable
    //    if (item == null || equipSlot == item.GetEquipSlot())
    //    {
    //        switch (equipSlot)
    //        {
    //            case EquipSlot.Pickaxe: SetPickaxeItem(item); break;
    //            case EquipSlot.Axe: SetAxeItem(item); break;
    //            case EquipSlot.Sickle: SetSickleItem(item); break;
    //            case EquipSlot.Helmet: SetHelmetItem(item); break;
    //            case EquipSlot.Chestplate: SetChestplateItem(item); break;
    //            case EquipSlot.Pants: SetPantItem(item); break;
    //            case EquipSlot.Boots: SetBootItem(item); break;
    //        }
    //    }
    //}
    //public bool IsSuitableSlot(EquipSlot equipSlot, ItemOld item)
    //{
    //    return equipSlot == item.GetEquipSlot();
    //}
    //private void SetPickaxeItem(ItemOld pickaxeItem)
    //{
    //    this.pickaxeItem = pickaxeItem;
    //    //player.SetEquipment(pickaxeItem);
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void SetAxeItem(ItemOld axeItem)
    //{
    //    this.axeItem = axeItem;
    //    //player.SetEquipment(axeItem);
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void SetSickleItem(ItemOld sickleItem)
    //{
    //    this.sickleItem = sickleItem;
    //    //player.SetEquipment(sickleItem);
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void SetHelmetItem(ItemOld helmetItem)
    //{
    //    this.helmetItem = helmetItem;
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void SetChestplateItem(ItemOld chestplateItem)
    //{
    //    this.chestplateItem = chestplateItem;
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void SetPantItem(ItemOld pantItem)
    //{
    //    this.pantItem = pantItem;
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}
    //private void SetBootItem(ItemOld bootItem)
    //{
    //    this.bootItem = bootItem;
    //    OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    //}

}
