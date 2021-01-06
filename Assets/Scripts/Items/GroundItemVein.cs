using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class GroundItemVein : Interactable, ISerializationCallbackReceiver
{
    public ItemVeinObject itemVeinObject;

    private int growthPhase;
    private bool isHarvestable;
    private KeyCode keyCode;

    private void Awake()
    {
        keyCode = KeyCode.F;
        isHarvestable = true;
        growthPhase = 0;

        GetComponent<Interactable>().SetInteractionInput(keyCode);
        GetComponent<Interactable>().SetInteractionFunc(GroundItemVeinInteraction);
    }

    public void GroundItemVeinInteraction(Player player)
    {
        TryHarvest(player);
    }

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
#if UNITY_EDITOR
        GetComponentInChildren<SpriteRenderer>().sprite = itemVeinObject.animation[0];
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
#endif
    }

    private void TryHarvest(Player player)
    {
        Debug.Log("Trying to harvest");

        #region Inits
        ItemObject sickleItem = player.equipment.container.slots[6].ItemObject;
        ItemObject pickaxeItem = player.equipment.container.slots[7].ItemObject;
        ItemObject axeItem = player.equipment.container.slots[8].ItemObject;
        #endregion

        if (isHarvestable)
        {
            #region Try Harvest with Sickle
            if (sickleItem?.itemType == itemVeinObject.toolRequired)
            {
                if (sickleItem.data.tier >= itemVeinObject.tierRequired)
                {
                    player.inventory.AddItem(new Item(itemVeinObject.item), 1);
                    GrowPlant();
                }
            }
            #endregion

            #region Try Harvest with Pickaxe
            else if (pickaxeItem?.itemType == itemVeinObject.toolRequired)
            {
                if (sickleItem.data.tier >= itemVeinObject.tierRequired)
                {
                    player.inventory.AddItem(new Item(itemVeinObject.item), 1);
                    GrowPlant();
                }
            }
            #endregion

            #region Try Harvest with Axe
            else if (axeItem?.itemType == itemVeinObject.toolRequired)
            {
                if (axeItem.data.tier >= itemVeinObject.tierRequired)
                {
                    player.inventory.AddItem(new Item(itemVeinObject.item), 1);
                    GrowPlant();
                }
            }
            #endregion

            else
            {
                Debug.Log("You require a tier " + itemVeinObject.tierRequired + " " + itemVeinObject.toolRequired.ToString() + " to harvest " + itemVeinObject.item.data.name);
            }
        }
        else
        {
            Debug.Log("You've harvested all you can already");
        }
    }

    private void GrowPlant()
    {
        /** minus 2 because:
         * (1) player cannot harvest an empty plant vein sprite (empty vein sprite is contained in itemVeinObject.anmation[]
         * (2) it's an array starting at index 0
         * **/

        //growth phase starts at 0
        growthPhase++;
        if (!(growthPhase < itemVeinObject.animation.Length - 2))
        {
            //plant can't grow anymore or it's completely harvested
            Debug.Log("" + itemVeinObject.item.data.name + " vein cannot be harvested further");
            isHarvestable = false;
        }
        GetComponentInChildren<SpriteRenderer>().sprite = itemVeinObject.animation[growthPhase];
    }


}
