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

    private void Start()
    {
        
        itemVein = GetComponent<ItemWorld>().GetItemVein();
        item = itemVein.GetItem();
        phases = itemVein.GetCount();
        curPhase = 0;

        animator = this.GetComponent<Animator>();
        animator.runtimeAnimatorController = itemVein.GetRuntimeAnimatorController();
    }
    
    public bool CanHarvest()
    {
        return curPhase <= phases;
    }
    public Item Harvest()
    {
         curPhase += 1;
         animator.SetFloat("Phase", curPhase);
         return item;
    }
}
