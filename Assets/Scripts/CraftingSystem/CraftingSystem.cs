using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem: MonoBehaviour
{
    public EventHandler OnMaterialChanged;

    private Item herb;
    private Item ore;
    private Item wood;
    private Item energyShard;

    private OutputSlot outputSlot;
    public enum CraftingSlot 
    {
        Herb,
        Ore,
        Wood,
        EnergyShard,
    }


    public void Craft(CraftingSlot herb, CraftingSlot ore, CraftingSlot wood)
    {

    }
    public void Craft(Item herb, Item ore, Item wood)
    {

    }
    public void Craft(Item herb, Item ore, Item wood, Item energyShard)
    {

    }
    public Item GetHerbItem()
    {
        return herb;
    }
    public Item GetOreItem()
    {
        return ore;
    }
    public Item GetWoodItem()
    {
        return wood;
    }
    public Item GetEnergyShardItem()
    {
        return energyShard;
    }
    public void SetHerbItem(Item herb)
    {
        this.herb = herb;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetOreItem(Item ore)
    {
        this.ore = ore;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetWoodItem(Item wood)
    {
        this.wood = wood;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetEnergyShardItem(Item energyShard)
    {
        this.energyShard = energyShard;
        OnMaterialChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetOutput(Item output)
    {
        outputSlot.SetOutputItem(output);
    }
}
