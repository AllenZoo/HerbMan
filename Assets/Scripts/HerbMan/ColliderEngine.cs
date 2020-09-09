using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEngine : MonoBehaviour
{
    private Player player;
    private ItemWorld itemWorld;
    private ItemWorldVein itemWorldVein;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        itemWorld = collider.GetComponent<ItemWorld>();
        itemWorldVein = collider.GetComponent<ItemWorldVein>();
        //For pickable items
        if (itemWorld != null)
        {
            if (itemWorldVein != null)
            {
                //If is Vein
                return;
            }
            else
            {
                //If is item
                player.GetInventory().AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
            }
        }
    }
    void Update()
    {
        if (itemWorldVein != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                //OnCollisionVein?.Invoke(this, EventArgs.Empty);
                if (itemWorldVein.CanHarvest())
                {
                    player.GetInventory().AddItem(itemWorldVein.Harvest());
                }
            }
        }
    }
}
