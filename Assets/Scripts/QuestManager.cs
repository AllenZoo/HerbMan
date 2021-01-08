using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Player_Quest player_Quest;

    private void Awake()
    {
        player_Quest  = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Quest>();

    }

    private void CheckQuestForCompletion()
    {

    }
}
