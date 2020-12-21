using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestRequestSlot : MonoBehaviour
{
    private Transform itemDisplay;
    private Transform countDisplay;
    private Transform checkBox;

    private bool isItem;
    private bool isCount;

    private void Awake()
    {
        itemDisplay = transform.Find("QRObject");
        countDisplay = transform.Find("QRCount");
        checkBox = transform.Find("CheckBox");
    }

    public void SetCount(int count)
    {
        if (count >= 1)
        {
            isCount = true;
            countDisplay.gameObject.GetComponent<Text>().text = "x " + count;
        }
        else
        {
            isCount = false;
        }
        UpdateVisibility();
    }
    public void SetCount(QuestRequest qr)
    {
        if (qr.GetItemCount() >= 1 && qr != null)
        {
            isCount = true;
            countDisplay.gameObject.GetComponent<Text>().text = "x " + qr.GetItemCount();
        }
        else
        {
            isCount = false;
        }
        UpdateVisibility();
    }
    public void SetQuestObject(ItemOld.ItemType itemType)
    {
        if (itemType != ItemOld.ItemType.Null)
        {
            isItem = true;
            itemDisplay.gameObject.GetComponent<Image>().sprite = ItemOld.GetSprite(itemType);
        }
        else
        {
            isItem = false;
        }
        UpdateVisibility();
    }
    public void SetQuestObject(QuestRequest qr)
    {
        if (qr.GetItemType() != ItemOld.ItemType.Null)
        {
            isItem = true;
            itemDisplay.gameObject.GetComponent<Image>().sprite = ItemOld.GetSprite(qr.GetItemType());
        }
        else
        {
            isItem = false;
        }
        UpdateVisibility();
    }
    public void SetCompletionState(bool isComplete)
    {
        checkBox.GetComponent<UI_CheckBox>().SetCheckMarkState(isComplete);
    }
    private void UpdateVisibility()
    {
        if (isItem && isCount)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Hide()
    {
        //transform.position = transform.position - new Vector3(1000, 1000, 0);
        this.gameObject.SetActive(false);
    }
    private void Show()
    {
        //transform.position = transform.position + new Vector3(1000, 1000, 0);
        this.gameObject.SetActive(true);
    }


}
