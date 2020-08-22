using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Player player;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }
    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 105f;


        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.Find("AccessButton").Find("UseButton").GetComponent<Button_UI>().ClickFunc = () =>
            {
                //Use Item
                inventory.UseItem(item);
            };

            itemSlotRectTransform.Find("AccessButton").Find("DropButton").GetComponent<Button_UI>().ClickFunc = () =>
            {
                //Drop Item
                Item duplicateItem = new Item { itemType = item.itemType, count = item.count };
                inventory.RemoveItem(item);
                ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image itemImage = itemSlotRectTransform.Find("ItemUI").GetComponent<Image>();
            itemImage.sprite = item.GetSprite();

            TextMeshProUGUI countText = itemSlotRectTransform.Find("CountText").GetComponent<TextMeshProUGUI>();
            if (item.count > 1)
            {
                countText.SetText(item.count.ToString());
            }
            else
            {
                countText.SetText("");
            }

            TextMeshProUGUI useText = itemSlotRectTransform.Find("AccessButton").Find("UseButton").Find("UseText").GetComponent<TextMeshProUGUI>();
            if (item.IsTool())
            {
                useText.SetText("Equip");
            }


            x++;
            if(x > 5)
            {
                x = 0;
                y--;
            }
        }
    }
}
