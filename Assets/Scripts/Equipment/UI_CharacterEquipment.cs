using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_CharacterEquipment : MonoBehaviour
{
    [SerializeField] private Transform pfItemUI;

    private Inventory inventory;
    private Transform itemContainer;

    private UI_CharacterEquipmentSlot pickaxeSlot;
    private UI_CharacterEquipmentSlot axeSlot;
    private UI_CharacterEquipmentSlot sickleSlot;

    private CharacterEquipment characterEquipment;
    private void Awake()
    {
        FindObjectOfType<GM_Initializer>().GetComponent<GM_Initializer>().SetUICharacterEquipment(this);

        itemContainer = transform.Find("itemContainer");
        pickaxeSlot = transform.Find("pickaxeSlot").GetComponent<UI_CharacterEquipmentSlot>();
        axeSlot = transform.Find("axeSlot").GetComponent<UI_CharacterEquipmentSlot>();
        sickleSlot = transform.Find("sickleSlot").GetComponent<UI_CharacterEquipmentSlot>();

        pickaxeSlot.OnItemDropped += PickaxeSlot_OnItemDropped;
        axeSlot.OnItemDropped += AxeSlot_OnItemDropped;
        sickleSlot.OnItemDropped += SickleSlot_OnItemDropped;

    }

    private void Start()
    {
        FindObjectOfType<UI_Manager>().GetComponent<UI_Manager>().SetUIEquipment(this.gameObject.transform);

    }
    public void SetCharacterEquipment(CharacterEquipment characterEquipment)
    {
        this.characterEquipment = characterEquipment;
        UpdateVisual();

        characterEquipment.OnEquipmentChanged += CharacterEquipment_OnEquipmentChanged;
    }

    private void PickaxeSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        TryDropEquipmentInSlot(CharacterEquipment.EquipSlot.Pickaxe, e.item);
    }

    private void AxeSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        TryDropEquipmentInSlot(CharacterEquipment.EquipSlot.Axe, e.item);
    }

    private void SickleSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        TryDropEquipmentInSlot(CharacterEquipment.EquipSlot.Sickle, e.item);
    }

    private void CharacterEquipment_OnEquipmentChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        foreach(Transform child in itemContainer)
        {
            Destroy(child.gameObject);    
        }

        Item pickaxeItem = characterEquipment.GetPickaxeItem();
        Item axeItem = characterEquipment.GetAxeItem();
        Item sickleItem = characterEquipment.GetSickleItem();

        RefreshEquipmentSlot(pickaxeSlot, pickaxeItem);
        RefreshEquipmentSlot(axeSlot, axeItem);
        RefreshEquipmentSlot(sickleSlot, sickleItem);
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
    private void RefreshEquipmentSlot(UI_CharacterEquipmentSlot characterEquipmentSlot, Item item)
    {
        if(item != null)
        {
            Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = characterEquipmentSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = true;

            UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
            uiItem.SetItem(item);
            uiItem.SetCount(item.count);
            uiItem.RefreshCountText();

            characterEquipmentSlot.transform.Find("emptyImage").gameObject.SetActive(false);
        }
        else
        {
            characterEquipmentSlot.transform.Find("emptyImage").gameObject.SetActive(true);
        }
    }
    private void TryDropEquipmentInSlot(CharacterEquipment.EquipSlot equipSlot, Item item)
    {
        //Item dropped into material slot, check if slot and item are suitble.
        if (characterEquipment.IsSuitableSlot(equipSlot, item))
        {
            //Check if slot is empty
            if (characterEquipment.GetSlotItem(equipSlot) == null)
            {
                //Move item from inventory to slot
                Item tempItem = new Item { itemType = item.itemType, count = item.count, durability = item.durability, system = Item.SystemType.equipment};
                characterEquipment.SetSlotItem(equipSlot, tempItem);
                inventory.RemoveItem(item);
                UI_ItemDrag.Instance.Hide();
            }
            else
            {
                //Item is present in slot, therefore switch items
                Item tempItemInCharacterEquipment = characterEquipment.GetSlotItem(equipSlot);
                Item tempItemForCharacterEquipmentSlot = new Item { itemType = item.itemType, count = item.count, durability = item.durability, system = Item.SystemType.equipment };

                //Move item from inventory to equipment slot
                characterEquipment.SetSlotItem(equipSlot, tempItemForCharacterEquipmentSlot);
                inventory.RemoveItem(item);

                //Move item from equipment slot to inventory
                inventory.AddItem(tempItemInCharacterEquipment);
                UI_ItemDrag.Instance.Hide();
            }
        }
        UI_ItemDrag.Instance.Hide();
    }
}
