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

    public void SetQuestUI(Quest quest, Sprite portrait)
    {
        if (quest != null && portrait != null)
        {
            HideEmptyQuestStatus();

            //Title
            SetTitle(quest.name);
            //Summary
            SetSummary(portrait, quest.summary);
            //Objective
            SetObjective(quest, quest.objectivePortrait, quest.objective);
            //Reward
            SetReward(quest);
        }
        else
        {
            HideAllUI();
            ShowEmptyQuestStatus();
        }
    }

    public void SetTitle(string title)
    {
        this.transform.Find("QuestTitle").GetComponentInChildren<TextMeshProUGUI>().text = title;
    }

    public void SetSummary(Sprite portrait, string summary)
    {
        if (portrait != null && summary != null)
        {
            this.transform.Find("Summary").gameObject.SetActive(true);
            this.transform.Find("Summary").Find("QuestGiverPortrait").GetComponentInChildren<Image>().sprite = portrait;
            this.transform.Find("Summary").Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = summary;
        }
        else
        {
            //summary and portrait == null
            this.transform.Find("Summary").gameObject.SetActive(false);
        }
    }

    public void SetObjective(Quest quest, Sprite item, string text)
    {
        if(quest != null && item != null && text != null)
        {
            this.transform.Find("Objective").gameObject.SetActive(true);
            this.transform.Find("Objective").Find("ItemPortrait").GetComponentInChildren<Image>().sprite = item;
            this.transform.Find("Objective").Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = text + " (" + quest.questGoal.currentAmount + "/" + quest.questGoal.requiredAmount + ")";
        }
        else
        {
            //quest, item and text == null
            this.transform.Find("Objective").gameObject.SetActive(false);
        }

    }

    public void SetReward(Quest quest)
    {
        var rewardInventory = this.transform.Find("Reward").GetComponent<DynamicInterface>().inventory;
        rewardInventory.Clear();

        if (quest != null)
        {
            this.transform.Find("Reward").gameObject.SetActive(true);
            for (int i = 0; i < quest.rewards.Length; i++)
            {
                var rewardRef = quest.rewards[i];
                rewardInventory.AddItem(new Item(rewardRef.item), rewardRef.amount);
            }
        }
        else
        {
            this.transform.Find("Reward").gameObject.SetActive(false);
        }
    }

    public void HideEmptyQuestStatus()
    {
        this.transform.Find("emptyDisplay").gameObject.SetActive(false);
    }

    public void ShowEmptyQuestStatus()
    {
        this.transform.Find("emptyDisplay").gameObject.SetActive(true);
    }

    public void HideAllUI()
    { 
        SetTitle(null);
        SetSummary(null, null);
        SetObjective(null, null, null);
        SetReward(null);

        HideAcptDecButtons();
        HideRewardButton();
        HideCheckBox();
    }
    public void HideAcptDecButtons()
    {
        this.transform.Find("AD_Buttons").Find("AcceptButton").gameObject.SetActive(false);
        this.transform.Find("AD_Buttons").Find("DeclineButton").gameObject.SetActive(false);
    }
    public void ShowAcptDecButtons()
    {
        this.transform.Find("AD_Buttons").Find("AcceptButton").gameObject.SetActive(true);
        this.transform.Find("AD_Buttons").Find("DeclineButton").gameObject.SetActive(true);
    }
    public void HideRewardButton()
    {
        this.transform.Find("CollectRewardButton").gameObject.SetActive(false);
    }
    public void ShowRewardButton()
    {
        this.transform.Find("CollectRewardButton").gameObject.SetActive(true);
    }
    public void HideUICloseButton()
    {
        this.transform.parent.Find("QuestCloseButton").gameObject.SetActive(false);
    }
    public void ShowUICloseButton()
    {
        this.transform.parent.Find("QuestCloseButton").gameObject.SetActive(true);
    }
    public void HideCheckBox()
    {
        this.transform.Find("Status").Find("checkbox").gameObject.SetActive(false);
    }
    public void ShowCheckBox()
    {
        Debug.Log("Showing Checkbox");
        this.transform.Find("Status").Find("checkbox").gameObject.SetActive(true);
        UpdateCheckBoxStatus();
    }

    public void UpdateCheckBoxStatus()
    {
        this.transform.Find("Status").GetComponentInChildren<CheckboxUI>().UpdateCheckmarkStatus();
    }

}
