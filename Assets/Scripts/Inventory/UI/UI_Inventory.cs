using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform pfItemUI;

    private CraftingSystem craftingSystem;
    private Player_Equipment characterEquipment;

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Player player;

    private void Awake()
    {
        FindObjectOfType<GM_Initializer>().GetComponent<GM_Initializer>().SetUIInventory(this);

        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        itemSlotTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {

    }
    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
    }
    public void SetCharacterEquipment(Player_Equipment characterEquipment)
    {
        this.characterEquipment = characterEquipment;
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
        float itemSlotCellSize = 125f;


        foreach (Inventory.InventorySlot inventorySlot in inventory.GetInventorySlotArray())
        {
            Item item = inventorySlot.GetItem();

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

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);

            if (!inventorySlot.IsEmpty())
            {
                //Not Empty, has Item
                Transform uiItemTransform = Instantiate(pfItemUI, itemSlotContainer);
                uiItemTransform.GetComponent<RectTransform>().anchoredPosition = itemSlotRectTransform.anchoredPosition;
                UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
                uiItem.SetItem(item);
                uiItem.SetSprite(item.GetSprite());
            }

            Inventory.InventorySlot tmpInventorySlot = inventorySlot;

            UI_ItemSlot uiItemSlot = itemSlotRectTransform.GetComponent<UI_ItemSlot>();

            uiItemSlot.SetOnDropAction(() => {
                Debug.Log("item dropped onto inventory slot");
                // Dropped on this UI Item Slot
                Item draggedItem = UI_ItemDrag.Instance.GetItem();
                if (draggedItem.system == Item.SystemType.equipment)
                {
                    Debug.Log("Equipment item dropped into inventory slot");
                    inventory.AddItemFromEquipmentSlot(draggedItem, tmpInventorySlot);
                    characterEquipment.SetSlotItem(draggedItem.GetEquipSlot(), null);
                    
                }
                else if (draggedItem.system == Item.SystemType.crafting)
                {
                    Debug.Log("Crafting item dropped into inventory slot");
                    inventory.AddItem(draggedItem, tmpInventorySlot);
                    craftingSystem.SetSlotItem(draggedItem.GetMaterialSlot(), null);
                }
                else if (draggedItem.system == Item.SystemType.inventory)
                {
                    Debug.Log("Inventory item dropped into inventory slot");
                    inventory.AddItem(draggedItem, tmpInventorySlot);
                }
                else if (draggedItem.system == Item.SystemType.craftedItem)
                {
                    Debug.Log("crafted item dropped into inventory");
                    inventory.AddItem(draggedItem);
                    craftingSystem.SetOutput(null);
                }
            });

            //Image itemImage = itemSlotRectTransform.Find("ItemUI").GetComponent<Image>();
            //itemImage.sprite = item.GetSprite();

            TextMeshProUGUI countText = itemSlotRectTransform.Find("CountText").GetComponent<TextMeshProUGUI>();
            if (inventorySlot.GetCount() > 1)
            {
                countText.SetText("x" + inventorySlot.GetCount().ToString());
            }
            else
            {
                countText.SetText("");
            }

            //TextMeshProUGUI useText = itemSlotRectTransform.Find("AccessButton").Find("UseButton").Find("UseText").GetComponent<TextMeshProUGUI>();
            //if (item.IsTool())
            //{
            //    useText.SetText("Equip");
            //}


            x++;
            if(x >= 5)
            {
                x = 0;
                y++;
            }
        }
    }
}
