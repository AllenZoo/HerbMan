using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(StaticInterface))]
public class CraftingUI : MonoBehaviour
{
    [SerializeField]
    private Button craftingButton;

    private InventoryObject craftingInventory;

    private InventorySlot herbItemSlot;
    private InventorySlot oreItemSlot;
    private InventorySlot woodItemSlot;
    private InventorySlot energyShardItemSlot;
    private InventorySlot recipeItemSlot;

    private InventorySlot outputSlot;

    private void Awake()
    {
        FindObjectOfType<UI_Manager>()?.SetUICrafting(this.gameObject);
        craftingInventory = GetComponent<StaticInterface>().inventory;
        craftingButton.onClick.AddListener(CraftingButtonPressed);

        #region Local Inits
        herbItemSlot = craftingInventory.container.slots[0];
        oreItemSlot = craftingInventory.container.slots[1];
        woodItemSlot = craftingInventory.container.slots[2];
        energyShardItemSlot = craftingInventory.container.slots[3];
        recipeItemSlot = craftingInventory.container.slots[4];
        outputSlot = craftingInventory.container.slots[5];
        #endregion
    }
    private void OnDisable()
    {
        MoveCraftingItemsToInventory();
    }

    private void CraftingButtonPressed()
    {
        Debug.Log("Crafting Button Pressed");
        ItemObject tempItem = TryCraft();
        if (tempItem)
        {
            outputSlot.UpdateSlot(new Item(tempItem), 1);
        }
    }
    private ItemObject TryCraft()
    {
        var craftingDatabase = craftingInventory.database.craftingRecipes;

        for (int i = 0; i < craftingDatabase.Length; i++)
        {
            Debug.Log("Trying to craft, going through recipe: " + i + " Recipe is: " + craftingDatabase[i].items[0].itemObject + " + " + craftingDatabase[i].items[1].itemObject + " + " + craftingDatabase[i].items[2].itemObject + " + " + craftingDatabase[i].items[3].itemObject);
            bool[] Craftable = new bool[4] { false, false, false, false };

            //Check herb
            if(craftingDatabase[i].items[0].itemObject == herbItemSlot.ItemObject
            && craftingDatabase[i].items[0].amount <= herbItemSlot.amount)
            {
                Craftable[0] = true;
            }

            //Check ore
            if (craftingDatabase[i].items[1].itemObject == oreItemSlot.ItemObject
            && craftingDatabase[i].items[1].amount <= oreItemSlot.amount)
            {
                Craftable[1] = true;
            }

            //Check wood
            if (craftingDatabase[i].items[2].itemObject == woodItemSlot.ItemObject
            && craftingDatabase[i].items[2].amount <= woodItemSlot.amount)
            {
                Craftable[2] = true;
            }

            //Check recipe
            if (craftingDatabase[i].items[3].itemObject == recipeItemSlot.ItemObject
            && craftingDatabase[i].items[3].amount <= recipeItemSlot.amount)
            {
                Craftable[3] = true;
            }

            //Check and return if all slots fulfill material requirements
            if(Craftable[0] && Craftable[1] && Craftable[2] && Craftable[3])
            {
                Debug.Log("Item is craftable");
                //Consume Materials
                herbItemSlot.UpdateSlot(herbItemSlot.amount - craftingDatabase[i].items[0].amount);
                oreItemSlot.UpdateSlot(oreItemSlot.amount - craftingDatabase[i].items[1].amount);
                woodItemSlot.UpdateSlot(woodItemSlot.amount - craftingDatabase[i].items[2].amount);
                recipeItemSlot.UpdateSlot(recipeItemSlot.amount - craftingDatabase[i].items[3].amount);

                return craftingDatabase[i].output;
            }

        }
        Debug.Log("Item is not craftable");
        return null;
    }
    private void MoveCraftingItemsToInventory()
    {
        if (herbItemSlot.item.id >= 0)
            FindObjectOfType<Player>().inventory.AddItem(herbItemSlot?.item, herbItemSlot.amount);

        if (oreItemSlot.item.id >= 0)
            FindObjectOfType<Player>().inventory.AddItem(oreItemSlot?.item, oreItemSlot.amount);

        if (woodItemSlot.item.id >= 0)
            FindObjectOfType<Player>().inventory.AddItem(woodItemSlot?.item, woodItemSlot.amount);

        if (energyShardItemSlot.item.id >= 0)
            FindObjectOfType<Player>().inventory.AddItem(energyShardItemSlot?.item, energyShardItemSlot.amount);

        if (recipeItemSlot.item.id >= 0)
            FindObjectOfType<Player>().inventory.AddItem(recipeItemSlot?.item, recipeItemSlot.amount);

        if (outputSlot.item.id >= 0)
            FindObjectOfType<Player>().inventory.AddItem(outputSlot?.item, outputSlot.amount);
        craftingInventory.Clear();
    }
}
