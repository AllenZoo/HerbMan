using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] UI_Inventory uiInventory;
    private Inventory inventory;


    private void Awake()
    {
        Instance = this;
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    public UI_Inventory GetUIInventory()
    {
        return uiInventory;
    }
    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            default:
                return;
        }
    }

}
