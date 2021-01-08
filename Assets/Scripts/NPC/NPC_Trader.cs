using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Trader : MonoBehaviour
{
    [SerializeField] 
    private List<QuestOld> questList;
    private int questNum =0;

    private void Awake()
    {
        //QuestRequest qrOne = new QuestRequest(Item.ItemType.Melom, 3);
        //QuestRequest qrTwo = new QuestRequest(Item.ItemType.Melom, 4);
        //QuestRequest qrThree = new QuestRequest(Item.ItemType.Melom, 5);
        //Quest quest = new Quest(qrOne, qrTwo, qrThree);
        //questList = new List<Quest>();
        //questList.Add(quest);


        //Adds empty quest so when last quest is finished, no null reference exception
        questList.Add(new QuestOld());
    }
    public QuestOld GetNextQuest()
    {
        QuestOld returnQuest = questList[questNum];
        questNum++;
        return returnQuest;
    }
}
