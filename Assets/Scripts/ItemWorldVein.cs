using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldVein : MonoBehaviour
{
    public Animator animator;
    //public VeinBar veinBar;
    private ItemVein itemVein;
    private Item item;
    private int phases;
    private int curPhase;

    private void Start()
    {
        itemVein = GetComponent<ItemWorld>().GetItemVein();
        animator = itemVein.GetAnimator();
        item = itemVein.GetItem();
        phases = itemVein.GetCount();
        curPhase = 0;
    }
    
    public bool CanHarvest()
    {
        return curPhase <= phases;
    }
    public Item Harvest()
    {
         curPhase += 1;
         return item;
    }
}
