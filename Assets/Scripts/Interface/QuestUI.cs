using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{

    private void Awake()
    {
        FindObjectOfType<UI_Manager>().SetUIQuest(this.gameObject);
    }

    public void SetTitle(string title)
    {
        this.transform.Find("QuestTitle").GetComponentInChildren<TextMeshProUGUI>().text = title;
    }

    public void SetSummary(Sprite portrait, string summary)
    {
        this.transform.Find("Summary").Find("QuestGiverPortrait").GetComponentInChildren<Image>().sprite = portrait;
        this.transform.Find("Summary").Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = summary;
    }

    public void SetObjective(Sprite item, string text)
    {
        this.transform.Find("Objective").Find("ItemPortrait").GetComponentInChildren<Image>().sprite = item;
        this.transform.Find("Objective").Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void SetReward(QuestObject questObject)
    {
        var rewardInventory = this.transform.Find("Reward").GetComponent<DynamicInterface>().inventory;
        for (int i = 0; i < questObject.quest.rewards.Length; i++)
        {
            var rewardRef = questObject.quest.rewards[i];
            rewardInventory.AddItem(new Item(rewardRef.item), rewardRef.amount);
        }

    }

    //private Vector3 GetPosition(int i)
    //{
        
    //}
}
