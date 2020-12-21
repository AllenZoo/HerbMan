using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private bool isOneTime;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Dialogue dialogue;

    public void TriggerDialogue()
    {
        if (arrow)
        {
            FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue, arrow);
        }
        else
        {
            FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
