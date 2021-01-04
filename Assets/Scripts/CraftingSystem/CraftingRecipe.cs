using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New crafting recipe", menuName = "Assets/Crafting/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public ItemObject[] items;
}
