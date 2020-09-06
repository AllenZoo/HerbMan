using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_CharacterEquipment : MonoBehaviour
{
    [SerializeField] private Transform pfItemUI;

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
        //Item dropped in Pickaxe Slot
        characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Pickaxe, e.item);
    }

    private void AxeSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        //Item dropped in Axe Slot
        characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Axe, e.item);
    }

    private void SickleSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        //Item dropped in Sickle Slot
        characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Sickle, e.item);
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
}
