using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private bool isOneTime;
    [SerializeField] private Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue);
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
        }
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
