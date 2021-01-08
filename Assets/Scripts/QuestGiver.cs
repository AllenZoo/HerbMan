using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(DialogueTrigger))]
public class QuestGiver : MonoBehaviour
{
    public QuestObject quest;
    public KeyCode keyCode;

    private DialogueTrigger dialogueTriggerRef;
    private Interactable interactableRef;

    private void Awake()
    {
        dialogueTriggerRef = GetComponent<DialogueTrigger>();

        interactableRef = GetComponent<Interactable>();
        interactableRef.SetInteractionInput(keyCode);
        interactableRef.SetInteractionFunc(QuestGiverInteraction);
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
    }
}
