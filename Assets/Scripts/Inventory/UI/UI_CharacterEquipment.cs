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
        itemContainer = transform.Find("itemContainer");
        pickaxeSlot = transform.Find("pickaxeSlot").GetComponent<UI_CharacterEquipmentSlot>();
        axeSlot = transform.Find("axeSlot").GetComponent<UI_CharacterEquipmentSlot>();
        sickleSlot = transform.Find("sickleSlot").GetComponent<UI_CharacterEquipmentSlot>();

        pickaxeSlot.OnItemDropped += PickaxeSlot_OnItemDropped;
        axeSlot.OnItemDropped += AxeSlot_OnItemDropped;
        sickleSlot.OnItemDropped += SickleSlot_OnItemDropped;
    }
    private void PickaxeSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        //Item dropped in Pickaxe Slot, check if slot and item are suitable
        if (characterEquipment.IsSuitableSlot(CharacterEquipment.EquipSlot.Pickaxe, e.item))
        {
            //Check if pickaxe equipment slot is empty
            if (characterEquipment.GetPickaxeItem() == null)
            {
                //Store item into equipment slot by removing from inventory
                characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Pickaxe, e.item);
                inventory.RemoveItem(e.item);
                ItemDragUI.Instance.Hide();
            }
            else
            {
                //Equipment is present in pickaxe slot, therefore add the item into inventory and equip dropped item
                Item tempItem = characterEquipment.GetPickaxeItem();
                characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Pickaxe, e.item);
                inventory.RemoveItem(e.item);
                inventory.AddItem(tempItem);
                ItemDragUI.Instance.Hide();
            }
        }
        ItemDragUI.Instance.Hide();
    }

    private void AxeSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        //Item dropped in Axe Slot, check if slot is suitable to item dropped
        if (characterEquipment.IsSuitableSlot(CharacterEquipment.EquipSlot.Axe, e.item))
        {
            //Check if pickaxe equipment slot is empty
            if (characterEquipment.GetAxeItem() == null)
            {
                //Store item into equipment slot by removing from inventory
                characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Axe, e.item);
                inventory.RemoveItem(e.item);
                ItemDragUI.Instance.Hide();
            }
            else
            {
                //Equipment is present in pickaxe slot, therefore add the item into inventory and equip dropped item
                Item tempItem = characterEquipment.GetAxeItem();
                characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Axe, e.item);
                inventory.RemoveItem(e.item);
                inventory.AddItem(tempItem);
                ItemDragUI.Instance.Hide();
            }
        }
        ItemDragUI.Instance.Hide();
    }

    private void SickleSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        //Item dropped in Pickaxe Slot, check if slot is suitable for item dropped
        if (characterEquipment.IsSuitableSlot(CharacterEquipment.EquipSlot.Sickle, e.item))
        {
            //Check if pickaxe equipment slot is empty
            if (characterEquipment.GetSickleItem() == null)
            {
                //Store item into equipment slot by removing from inventory
                characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Sickle, e.item);
                inventory.RemoveItem(e.item);
                ItemDragUI.Instance.Hide();
            }
            else
            {
                //Equipment is present in pickaxe slot, therefore add the item into inventory and equip dropped item
                Item tempItem = characterEquipment.GetSickleItem();
                characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Sickle, e.item);
                inventory.RemoveItem(e.item);
                inventory.AddItem(tempItem);
                ItemDragUI.Instance.Hide();
            }
        }
        ItemDragUI.Instance.Hide();
    }

    public void SetCharacterEquipment(CharacterEquipment characterEquipment)
    {
        this.characterEquipment = characterEquipment;
        UpdateVisual();

        characterEquipment.OnEquipmentChanged += CharacterEquipment_OnEquipmentChanged;
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

        if(pickaxeItem != null)
        {
            Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = pickaxeSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = false;
            ItemUI uiItem = uiItemTransform.GetComponent<ItemUI>();
            uiItem.SetItem(pickaxeItem);
            pickaxeSlot.transform.Find("emptyImage").gameObject.SetActive(false);
        }
        else
        {
            pickaxeSlot.transform.Find("emptyImage").gameObject.SetActive(true);
        }

        if(axeItem != null)
        {
            Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = axeSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = false;
            ItemUI uiItem = uiItemTransform.GetComponent<ItemUI>();
            uiItem.SetItem(axeItem);
            axeSlot.transform.Find("emptyImage").gameObject.SetActive(false);
        }
        else
        {
            axeSlot.transform.Find("emptyImage").gameObject.SetActive(true);
        }

        if (sickleItem != null)
        {
            Transform uiItemTransform = Instantiate(pfItemUI, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = sickleSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = false;
            ItemUI uiItem = uiItemTransform.GetComponent<ItemUI>();
            uiItem.SetItem(sickleItem);
            sickleSlot.transform.Find("emptyImage").gameObject.SetActive(false);
        }
        else
        {
            sickleSlot.transform.Find("emptyImage").gameObject.SetActive(true);
        }
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
}
