using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{ 
    public GoalType goalType;

    public ItemObject requiredItem;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemGathered(ItemObject item)
    {
        if (goalType == GoalType.Gathering)
        {
            if (requiredItem.data.id == item.data.id)
            {
                currentAmount++;
            }
        }
        Debug.Log(currentAmount);
    }

    public void EnemyKilled(Enemy_Base enemy)
    {
        if(goalType == GoalType.Kill)
        {

        }
    }

    
}

public enum GoalType
{
    Gathering,
    Kill,
    Adventure,
}
