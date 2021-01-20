using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Assets/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] itemObjects;
    public CraftingRecipe[] craftingRecipes;

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < itemObjects.Length; i++)
        {
            if (itemObjects[i].data.id != i) {
                itemObjects[i].data.id = i;
            }
        }
    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
        UpdateID();
    }
}
