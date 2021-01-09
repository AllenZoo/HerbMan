using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(DialogueTrigger))]
public class QuestGiver : MonoBehaviour
{
    public QuestObject questObject;
    public Sprite portrait;
    public KeyCode keyCode;

    private Player playerRef;
    private DialogueTrigger dialogueTriggerRef;
    private Interactable interactableRef;
    private QuestUI questUI;

    private void Awake()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        dialogueTriggerRef = GetComponent<DialogueTrigger>();

        interactableRef = GetComponent<Interactable>();
        interactableRef.SetInteractionInput(keyCode);
        interactableRef.SetInteractionFunc(QuestGiverInteraction);
    }

    private void OpenQuestWindow()
    {
        FindObjectOfType<UI_Manager>().OpenQuest();

        questUI = FindObjectOfType<UI_Manager>().GetQuestUI().GetComponent<QuestUI>();
        questUI.transform.parent.Find("Buttons").Find("AcceptButton").GetComponent<Button>().onClick.AddListener(AcceptQuest);
        questUI.transform.parent.Find("Buttons").Find("DeclineButton").GetComponent<Button>().onClick.AddListener(DeclineQuest);

        //Title
        questUI.SetTitle(questObject.quest.name);

        //Summary
        questUI.SetSummary(portrait, questObject.quest.summary);

        //Objective
        questUI.SetObjective(questObject.quest.objectivePortrait, questObject.quest.objective);

        //Reward
        questUI.SetReward(questObject);
    }
    private void CloseQuestWindow()
    {
        FindObjectOfType<UI_Manager>().CloseQuest();
    }

    private void QuestGiverInteraction(Player player)
    {
        StartCoroutine(QuestGiveDialogue());
    }
    private IEnumerator QuestGiveDialogue()
    {
        dialogueTriggerRef.TriggerDialogue();
        yield return new WaitUntil(() => dialogueTriggerRef.isDialogueDone == true);
        Debug.Log("Displaying accept or decline screen");
        OpenQuestWindow();

    }

    private void AcceptQuest()
    {
        Debug.Log("Quest Accepted" + ": " + questObject.quest.name);
        playerRef.player_Quest.AddQuest(questObject.quest);
        CloseQuestWindow(); 
    }
    private void DeclineQuest()
    {
        Debug.Log("Quest Declined");
        CloseQuestWindow();
    }
}
