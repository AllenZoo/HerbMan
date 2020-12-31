using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Vein", menuName = "Assets/Items/ItemVein")]
public class ItemVeinObject : ScriptableObject
{
    public ItemObject item;
    public ResourceType resourceType;
    public Sprite[] animation;
}
public enum ResourceType { 
    Herb,
    Ore,
    Wood,
}
