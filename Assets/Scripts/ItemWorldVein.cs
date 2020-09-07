using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldVein : MonoBehaviour
{
    private Animator animator;

    //public VeinBar veinBar;
    private ItemVein itemVein;
    private Item item;
    private int phases;
    private int curPhase;

    private CharacterEquipment characterEquipment;

    private void OnTriggerEnter2D(Collider2D player)
    {
        characterEquipment = player.GetComponent<CharacterEquipment>();
    }

    private void Start()
    {
        
        itemVein = GetComponent<ItemWorld>().GetItemVein();
        item = itemVein.GetItem();
        phases = itemVein.GetAnimPhases();
        curPhase = 0;

        animator = this.GetComponent<Animator>();
        animator.runtimeAnimatorController = itemVein.GetRuntimeAnimatorController();
    }
    
    public bool CanHarvest()
    {
        if(curPhase <= phases)
        {
            //There are more phases, continue screening
            if (item.IsOre())
            {
                //Item is ore type
                if (item.GetTier() <= characterEquipment.GetPickaxeItem().GetTier())
                {
                    return true;
                }
                else
                {
                    //Pickaxe is not high enough tier
                    return false;
                }

            }
            else if (item.IsWood())
            {
                //Item is wood type
                if(item.GetTier() <= characterEquipment.GetAxeItem().GetTier())
                {
                    return false;
                }
                else
                {
                    //axe is not high enough tier
                    return false;
                }
            }
            else if (item.IsHerb())
            {
                //Item is herb type
                if (item.GetTier() <= characterEquipment.GetSickleItem().GetTier())
                {
                    return true;
                }
                else
                {
                    //Sickle is not high enough tier
                    return false;
                }

            }
        }
        return false;
    }
    public Item Harvest()
    {
         curPhase += 1;
         animator.SetFloat("Phase", curPhase);
         return item;
    }
}
