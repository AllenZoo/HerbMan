using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item Vein", menuName = "Assets/Items/ItemVein")]
public class ItemVeinObject : ScriptableObject
{
    public ItemObject item;
    public Sprite[] animation;
    public int tierRequired;
    public ItemType toolRequired;
}

