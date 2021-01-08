using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof (Collectable))]
public class GroundItem : Collectable, ISerializationCallbackReceiver
{
    public ItemObject item;

    private void Awake()
    {
        GetComponent<Collectable>().SetCollectFunction(GroundItemCollect);

        //Resets collider so there's no funky triggers
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
    }

    public void GroundItemCollect(Player player)
    {
        player.inventory.AddItem(new Item(item), 1);
        Destroy(gameObject);
    }

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
#if UNITY_EDITOR
        GetComponentInChildren<SpriteRenderer>().sprite = item.sprite;
        //this.name = "GROUND ITEM " + item.name;
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
#endif
    }
}
