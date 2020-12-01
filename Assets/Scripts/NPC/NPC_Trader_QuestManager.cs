using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField] private List<QuestRequest> questRequestList;

    public Quest()
    {
        questRequestList = new List<QuestRequest>();
    }
    public Quest(QuestRequest qrOne)
    {
        questRequestList = new List<QuestRequest>();
        questRequestList.Add(qrOne);
    }
    public Quest(QuestRequest qrOne, QuestRequest qrTwo)
    {
        questRequestList = new List<QuestRequest>();
        questRequestList.Add(qrOne);
        questRequestList.Add(qrTwo);
    }
    public Quest(QuestRequest qrOne, QuestRequest qrTwo, QuestRequest qrThree)
    {
        questRequestList = new List<QuestRequest>();
        questRequestList.Add(qrOne);
        questRequestList.Add(qrTwo);
        questRequestList.Add(qrThree);
    }
    public Quest(List<QuestRequest> questRequestList)
    {
        this.questRequestList = questRequestList;
    }
    public void SetQuest(QuestRequest qrOne)
    {
        questRequestList.Clear();
        questRequestList.Add(qrOne);
    }
    public void SetQuest(QuestRequest qrOne, QuestRequest qrTwo)
    {
        questRequestList.Clear();
        questRequestList.Add(qrOne);
        questRequestList.Add(qrTwo);
    }
    public void SetQuest(QuestRequest qrOne, QuestRequest qrTwo, QuestRequest qrThree)
    {
        questRequestList.Clear();
        questRequestList.Add(qrOne);
        questRequestList.Add(qrTwo);
        questRequestList.Add(qrThree);
    }
    public List<QuestRequest> GetRequestList()
    {
        return questRequestList;
    }
}
[System.Serializable]
public class QuestRequest
{
    [SerializeField] private Item item;
    public QuestRequest()
    {
        item = new Item { itemType = Item.ItemType.Null, count = 0 };
    }
    public QuestRequest(Item.ItemType itemType, int count)
    {
        item = new Item { itemType = itemType, count = count };
    }
    public int GetItemCount()
    {
        return item.count;
    }
    public Item.ItemType GetItemType()
    {
        return item.itemType;
    }

}
public class NPC_Trader_QuestManager : MonoBehaviour
{
    private GameObject player;
    private NPC_Trader npcTrader;
    private UI_TraderQuest ui_TQ;

    private Quest currentQuest;
    private List<Quest> questList;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        npcTrader = GetComponent<NPC_Trader>();
        currentQuest = npcTrader.GetNextQuest();
    }

    private void Start()
    {

    }

    private void CompleteQuest()
    {
        if (ui_TQ.IsQuestComplete())
        {
            
        }
    }


    public Quest GetQuest()
    {
        return currentQuest;
    }
    
}
