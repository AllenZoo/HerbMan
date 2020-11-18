using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestRequestSlot : MonoBehaviour
{
    private Transform itemDisplay;
    private Transform countDisplay;
    private Transform checkBox;
    private Transform itemBackground;

    private bool isItem;
    private bool isCount;

    private void Start()
    {
        itemDisplay = transform.Find("QRObject");
        countDisplay = transform.Find("QRCount");
        checkBox = transform.Find("CheckBox");
        itemBackground = transform.Find("QRObjectBackground");
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
    public void SetQuestObject(Item.ItemType itemType)
    {
        if (itemType != Item.ItemType.Null) {
            isItem = true;
            itemDisplay.gameObject.GetComponent<Image>().sprite = Item.GetSprite(itemType);
        }
        else
        {
            isItem = false;
        }
        UpdateVisibility();
    }
    public void SetQuestObject(QuestRequest qr)
    {
        if (qr.GetItemType() != Item.ItemType.Null)
        {
            isItem = true;
            itemDisplay.gameObject.GetComponent<Image>().sprite = Item.GetSprite(qr.GetItemType());
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
        if(isItem && isCount)
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
        //countDisplay.gameObject.SetActive(false);
        //itemDisplay.GetComponent<Image>().enabled = false;
        //checkBox.gameObject.SetActive(false);
        //itemBackground.gameObject.SetActive(false);
    }
    private void Show()
    {
        //countDisplay.gameObject.SetActive(true);
        //itemDisplay.gameObject.SetActive(true);
        //checkBox.gameObject.SetActive(true);
        //itemBackground.gameObject.SetActive(true);
    }
}
