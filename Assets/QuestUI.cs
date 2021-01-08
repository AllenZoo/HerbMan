using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public GameObject summary;
    public GameObject objective;
    public GameObject reward;

    public GameObject rewardPFB;

    public void SetSummary(string text)
    {
        summary.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetObjective(ItemObject item, string text)
    {
        objective.transform.Find("ItemPortrait").GetComponentInChildren<Image>().sprite = item.sprite;
        objective.transform.Find("Description").GetComponentInChildren<Text>().text = text;
    }

    public void SetReward(ItemObject[] items, Quest quest)
    {
        
        for (int i = 0; i < items.Length; i++)
        {
            var obj = Instantiate(rewardPFB, Vector3.zero, Quaternion.identity, transform);
            //obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            //obj.GetComponent<RewardDisplay>().SetItemDisplay(items[i]);
            obj.GetComponent<RewardDisplay>().SetAmountText(quest.moneyReward);
        }
        //
    }

    //private Vector3 GetPosition(int i)
    //{
        
    //}
}
