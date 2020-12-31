using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Assets/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] items;

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].data.id != i) {
                items[i].data.id = i;
            }
        }
    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {

    }
}
