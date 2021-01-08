using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collection Quest", menuName = "Assets/Quests/Collection Quest")]
public class CollectionQuestObject : QuestObject
{
    public ItemObject[] itemsToCollect;

    private void Awake()
    {
        questType = QuestType.Collection;
    }
}
