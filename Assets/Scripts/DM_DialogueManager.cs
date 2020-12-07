using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DM_DialogueManager : MonoBehaviour
{
    private Text nameText;
    private Text dialogueText;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();

        nameText = this.transform.Find("nameText").GetComponent<Text>();
        dialogueText = this.transform.Find("dialogueText").GetComponent<Text>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {

    }
}
