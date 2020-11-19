using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    List<QuestRequest> questRequestList;

    public Quest()
    {
        questRequestList = new List<QuestRequest>();
    }
    public Quest(QuestRequest qrOne)
    {
        questRequestList = new List<QuestRequest>();
        questRequestList.Add(qrOne);
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
public class QuestRequest
{
    private Item item;
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
public class NPC_Trader_Shop : MonoBehaviour
{
    private GameObject player;
    private Quest currentQuest;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        QuestRequest qrOne = new QuestRequest(Item.ItemType.WaterHerb, 5);
        QuestRequest qrTwo = new QuestRequest(Item.ItemType.Hemm, 4);
        QuestRequest qrThree = new QuestRequest(Item.ItemType.Stick, 3);
        currentQuest = new Quest();
        currentQuest.SetQuest(qrOne, qrTwo, qrThree);
    }
    
    public Quest GetQuest()
    {
        return currentQuest;
    }
    
}
