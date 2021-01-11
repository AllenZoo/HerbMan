using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxUI : MonoBehaviour
{
    private Player player;
    private Transform checkMark;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        checkMark = transform.Find("checkmark");

    }

    private void Start()
    {
        player.player_Event.RegisterQuestCompleted(SetCheckMarkState);
    }

    public void UpdateCheckmarkStatus()
    {
        if (player.player_Quest.GetCurQuest() != null)
        {
            SetCheckMarkState(player.player_Quest.GetCurQuest());
        }
    }

    public void SetCheckMarkState(Quest quest)
    {
        Debug.Log(quest.isComplete);
        if (quest.isComplete == true)
        {
            SetCheckMarkState(true);
        }
        else
        {
            SetCheckMarkState(false);
        }
    }

    public void SetCheckMarkState(bool isActive)
    {
        checkMark.gameObject.SetActive(isActive);
    }
}
