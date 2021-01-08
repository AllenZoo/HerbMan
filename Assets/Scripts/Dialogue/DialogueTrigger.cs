using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool isDialogueDone;
    [SerializeField] private bool isOneTime;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private bool canBeTriggeredByCollision;
    public void TriggerDialogue()
    {
        if (arrow)
        {
            FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue, arrow);
            FindObjectOfType<UI_DialogueManager>().SetCurrentDialogueTrigger(this);
        }
        else
        {
            FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<UI_DialogueManager>().SetCurrentDialogueTrigger(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && canBeTriggeredByCollision)
        {
            TriggerDialogue();
            if (isOneTime)
            {
                Deactivate();
            }
            if (arrow)
            {
                arrow.SetActive(true);
                arrow.GetComponent<TutorialArrow>().StartFlashing();
            }
        }
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
