using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundItemVein : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemVeinObject itemVeinObject;

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
#if UNITY_EDITOR
        GetComponentInChildren<SpriteRenderer>().sprite = itemVeinObject.animation[0];
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
#endif
    }
}
