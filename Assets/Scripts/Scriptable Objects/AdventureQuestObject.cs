using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Adventure Quest", menuName = "Assets/Quests/Adventure Quest")]
public class AdventureQuestObject : QuestObject
{
    public GameObject npcToMeet;

    private void Awake()
    {
        questType = QuestType.Adventure;
    }
}
