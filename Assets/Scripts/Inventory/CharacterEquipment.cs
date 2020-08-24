using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public event EventHandler OnEquipmentChanged;

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

    public void SetPickAxeItem(Item pickaxeItem)
    {
        this.pickaxeItem = pickaxeItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetAxeItem(Item axeItem)
    {
        this.axeItem = axeItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetSickleItem(Item sickleItem)
    {
        this.sickleItem = sickleItem;
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }
}
