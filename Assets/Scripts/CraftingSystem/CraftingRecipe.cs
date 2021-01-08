using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New crafting recipe", menuName = "Assets/Crafting/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    [Header("Size of array should be 4. [0] = herbItem, [1] = oreItem, [2] = woodItem, [3] = recipeItem")]
    public CraftingRecipeItem[] items;
    public ItemObject output;

    public CraftingRecipe(CraftingRecipeItem[] craftingRecipeItems)
    {
        items = craftingRecipeItems;
    }

}

[System.Serializable]
public class CraftingRecipeItem
{
    public ItemObject itemObject;
    public int amount;
}
