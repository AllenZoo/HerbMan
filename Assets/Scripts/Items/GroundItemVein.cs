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

        //Resets collider so there's no funky triggers
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
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
        //this.name = "GROUND " + itemVeinObject.name;
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
                    player.player_Event.InvokeItemAddedToInventory(itemVeinObject.item);
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
                    player.player_Event.InvokeItemAddedToInventory(itemVeinObject.item);
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
                    player.player_Event.InvokeItemAddedToInventory(itemVeinObject.item);
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
        //growth phase starts at 0
        growthPhase++;

        //Check if plant can grow anymore
        if (growthPhase >= (itemVeinObject.animation.Length - 1))
        {
            //plant can't grow anymore or it's completely harvested
            Debug.Log("" + itemVeinObject.item.data.name + " vein cannot be harvested further");
            isHarvestable = false;
        }
        GetComponentInChildren<SpriteRenderer>().sprite = itemVeinObject.animation[growthPhase];
    }


}
