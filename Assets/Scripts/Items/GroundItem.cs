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
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
#endif
    }
}
