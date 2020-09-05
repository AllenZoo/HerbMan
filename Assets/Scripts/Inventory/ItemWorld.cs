using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }
    public static ItemWorld SpawnItemVein(Vector3 position, ItemVein itemVein)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemVein, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItemVein(itemVein);

        return itemWorld;
    }
    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 2f, ForceMode2D.Impulse);
        return itemWorld;
    }

    private Item item;
    private ItemVein itemVein;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }
    public void SetItemVein(ItemVein itemVein)
    {
        this.itemVein = itemVein;
        spriteRenderer.sprite = itemVein.GetSprite();
    }
    public Item GetItem()
    {
        return item;
    }
    public ItemVein GetItemVein()
    {
        return itemVein; 
    }

   

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
