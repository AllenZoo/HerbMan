using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_QuestManager : MonoBehaviour
{
    private GameObject uiQuestGameObject;
    private Player_Quest player_Quest;
    private Quest curQuest;
    private Sprite questPortrait;

    private void Awake()
    {
        player_Quest  = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Quest>();
    }
    private void Start()
    {
        uiQuestGameObject = FindObjectOfType<UI_Manager>().GetQuestUI();
    }

    public void SetQuest(Quest quest, Sprite portrait)
    {
        curQuest = quest;
        questPortrait = portrait;

        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        QuestUI questUI = uiQuestGameObject.GetComponent<QuestUI>();
        questUI.SetQuestUI(curQuest, questPortrait);
    }
}
