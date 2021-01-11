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

    private Player player;
    private DialogueTrigger dialogueTriggerRef;
    private Interactable interactableRef;
    private QuestUI questUI;

    private bool questIsGiven;
    private bool rewardGiven;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        dialogueTriggerRef = GetComponent<DialogueTrigger>();

        interactableRef = GetComponent<Interactable>();
        interactableRef.SetInteractionInput(keyCode);
        interactableRef.SetInteractionFunc(QuestGiverInteraction);

        questIsGiven = false;
        rewardGiven = false;
    }

    private void OpenQuestWindow()
    {
        questUI = FindObjectOfType<UI_Manager>().GetQuestUI().GetComponent<QuestUI>();

        questUI.ShowAcptDecButtons();
        questUI.HideRewardButton();
        questUI.HideCheckBox();

        questUI.transform.Find("AD_Buttons").Find("AcceptButton").GetComponent<Button>().onClick.AddListener(AcceptQuest);
        questUI.transform.Find("AD_Buttons").Find("DeclineButton").GetComponent<Button>().onClick.AddListener(DeclineQuest);

        FindObjectOfType<UI_Manager>().SetQuestGiverRef(questObject.quest, portrait);
        FindObjectOfType<UI_Manager>().OpenQuestUI();
    }

    private void OpenCompletedQuestWindow()
    {
        questUI = FindObjectOfType<UI_Manager>().GetQuestUI().GetComponent<QuestUI>();

        questUI.HideAcptDecButtons();
        questUI.ShowRewardButton();
        questUI.ShowCheckBox();

        questUI.transform.Find("CollectRewardButton").GetComponentInChildren<Button>().onClick.AddListener(CollectReward);

        FindObjectOfType<UI_Manager>().SetQuestGiverRef(questObject.quest, portrait);
        FindObjectOfType<UI_Manager>().OpenQuestUI();
    }

    private void CloseQuestWindow()
    {
        FindObjectOfType<UI_Manager>().CloseQuestGiverWindow();
    }

    private void QuestGiverInteraction(Player player)
    {
        if (!questIsGiven)
        {
            StartCoroutine(QuestGiveDialogue());
        }

        else if (player.player_Quest.IsQuestComplete())
        {
            OpenCompletedQuestWindow();
        }
        else
        {
            //Quest is given but no complete
        }

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
        player.player_Quest.AddQuest(questObject.quest);

        questIsGiven = true;
        questUI.HideAcptDecButtons();
        questUI.ShowCheckBox();

        CloseQuestWindow(); 
    }
    private void DeclineQuest()
    {
        Debug.Log("Quest Declined");
        CloseQuestWindow();
    }
    private void CollectReward()
    {

        for (int i = 0; i < questObject.quest.rewards.Length; i++)
        {
            player.inventory.AddItem(new Item (questObject.quest.rewards[i].item), questObject.quest.rewards[i].amount);
            rewardGiven = true;
        }
        if (rewardGiven)
        {
            Debug.Log(questObject.quest.questGoal.requiredItem.name);
            player.inventory.RemoveItem(new Item(questObject.quest.questGoal.requiredItem), questObject.quest.questGoal.requiredAmount);
        }

        FindObjectOfType<UI_Manager>().SetQuestGiverRef(null, null);
        CloseQuestWindow();
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Resetting Quest");
        questObject.quest.questGoal.currentAmount = 0;
    }
}
