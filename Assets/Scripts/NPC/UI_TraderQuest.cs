using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TraderQuest : MonoBehaviour
{
    private GameObject player;

    private Quest quest;
    private QuestRequest qrOne;
    private QuestRequest qrTwo;
    private QuestRequest qrThree;

    private List<bool> completionList;

    private UI_QuestRequestSlot qrSlotOne;
    private UI_QuestRequestSlot qrSlotTwo;
    private UI_QuestRequestSlot qrSlotThree;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().GetInventory().OnItemListChanged += UI_TraderQuest_OnItemListChanged;

        GetCurQuest();
        InitQuestRequest();

        qrSlotOne = transform.Find("QuestRequestSlotOne").GetComponent<UI_QuestRequestSlot>();
        qrSlotTwo = transform.Find("QuestRequestSlotTwo").GetComponent<UI_QuestRequestSlot>();
        qrSlotThree = transform.Find("QuestRequestSlotThree").GetComponent<UI_QuestRequestSlot>();

        RefreshUI();

        //TEST AREA

    }

    private void UI_TraderQuest_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshUI();
    }

    public bool IsQuestComplete()
    {
        foreach(bool state in completionList)
        {
            if(state == false)
            {
                return false;
            }
        }

        return true;
    }

    public void RefreshUI()
    {
        InitQuestRequest();
        completionList = CheckInventory();

        //Refresh Slot info
        qrSlotOne.gameObject.SetActive(true);
        qrSlotOne.SetQuestObject(qrOne);
        qrSlotOne.SetCount(qrOne);

        qrSlotTwo.gameObject.SetActive(true);
        qrSlotTwo.SetQuestObject(qrTwo);
        qrSlotTwo.SetCount(qrTwo);

        qrSlotThree.gameObject.SetActive(true);
        qrSlotThree.SetQuestObject(qrThree);
        qrSlotThree.SetCount(qrThree);

        //Check if Quest Request exists for each slot

        //Checkbox
        int count = 0;
        foreach (bool isComplete in completionList)
        {
            if (count == 0)
            {
                qrSlotOne.SetCompletionState(isComplete);
            }
            else if (count == 1)
            {
                qrSlotTwo.SetCompletionState(isComplete);
            }
            else if (count == 2)
            {
                qrSlotThree.SetCompletionState(isComplete);
            }
            count++;
        }

    }
    private void GetCurQuest()
    {
        quest = GameObject.FindGameObjectWithTag("NPC_Trader").GetComponent<NPC_Trader_QuestManager>().GetQuest();
    }
    private void InitQuestRequest()
    {
        qrOne = new QuestRequest();
        qrTwo = new QuestRequest();
        qrThree = new QuestRequest();

        int count = 0;
        foreach (QuestRequest qr in quest.GetRequestList())
        {
            if (count == 0)
            {
                qrOne = qr;
            }
            else if (count == 1)
            {
                qrTwo = qr;
            }
            else if (count == 2)
            {
                qrThree = qr;
            }
            count++;
        }


    }
    private List<bool> CheckInventory()
    {
        List<bool> boolList = new List<bool>();

        Inventory inv = player.GetComponent<Player>().GetInventory();
        foreach (QuestRequest questRequest in quest.GetRequestList())
        {
            int count = 0;
            bool enoughItem = false;
            foreach (Item item in inv.GetItemList())
            {

                if (!enoughItem && questRequest.GetItemType() == item.itemType)
                {
                    count += item.count;
                }
                if (questRequest.GetItemCount() <= count)
                {
                    enoughItem = true;
                }
            }

            boolList.Add(enoughItem);
        }
        return boolList;
    }

    //DEBUGGING
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RefreshUI();
        }
    }
}
