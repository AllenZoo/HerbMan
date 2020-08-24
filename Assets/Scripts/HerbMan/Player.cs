using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] UI_Inventory uiInventory;
    private Inventory inventory;


    private void Awake()
    {
        Instance = this;
        inventory = new Inventory(UseItem, 20);
        //uiInventory.SetInventory(inventory);
        //uiInventory.SetPlayer(this);

 
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
        if (item.IsTool())
        {
            Debug.Log("Using Tool!");
            //Equip Tool
            switch (item.itemType)
            {
                default: break;
                case Item.ItemType.StonePickaxe: break;

            }
        }

        if (item.IsMaterial())
        {
            switch (item.itemType)
            {
                default: break;
            }
        }
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
