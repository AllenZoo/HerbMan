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
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(1, 2), new Item { itemType = Item.ItemType.AmatitePickaxe, count = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(2, 1), new Item { itemType = Item.ItemType.AmatiteAxe, count = 1 });
        
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
}
